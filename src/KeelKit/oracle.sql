
-----------��------------------------------------------------------
SELECT

  a.TABLE_NAME  AS ����,
 -- a.COLUMN_ID AS ���,
  a.COLUMN_NAME AS ƴ����,
  decode(
  (
      SELECT COUNT(*)       
      FROM    
      USER_CONS_COLUMNS aa,
      user_constraints bb
      WHERE 
      aa.owner=bb.owner AND 
      aa.table_name=bb.table_name AND
      aa.constraint_name=bb.constraint_name  AND 
      aa.table_name =a.TABLE_NAME AND 
      aa.column_name=a.COLUMN_NAME AND
      bb.constraint_type='P '
  ) ,'0','N','1','Y')   AS ����,
  decode(
  (
      SELECT COUNT(*)       
      FROM    
      USER_CONS_COLUMNS aa,
      user_constraints bb
      WHERE 
      aa.owner=bb.owner AND
      aa.table_name=bb.table_name AND
      aa.constraint_name=bb.constraint_name  AND 
      aa.table_name =a.TABLE_NAME AND 
      aa.column_name=a.COLUMN_NAME AND
      bb.constraint_type='C '
  ) ,'0','N','1','Y') AS ���,
  a.NULLABLE AS �Ƿ�Ϊ��,
  a.DATA_TYPE AS ��������,
  a.DATA_LENGTH AS ���ݳ���,
  -- a.AS < http://a.as/> С��λ��,
  (
    SELECT comments FROM USER_COL_COMMENTS ss WHERE 
ss.table_name=a.TABLE_NAME AND ss.column_name=a.COLUMN_NAME
  ) AS ����������
  from   user_tab_columns   a

 

---���ݿ����---------------------------------------------------------------------------

SELECT * FROM
(
(SELECT
   a.object_type||'�ϼ�:' AS ��������,
   to_char( COUNT(*))||'��' AS ˵��,
    '�ϼ�' AS ��������,
    '-' AS ����ʱ��,
    '-' AS ����޸�ʱ��
    FROM
USER_OBJECTS a
WHERE 
 a.object_type='FUNCTION'
    OR a.object_type='PACKAGE'
    or a.object_type='PROCEDURE'
 or a.object_type='SEQUENCE'
 or a.object_type='TABLE' 
GROUP BY a.object_type
)
UNION
(
    SELECT 
           a.object_name AS ��������,           
           (select comments from USER_TAB_COMMENTS where 
table_name=a.object_name) AS ˵��,
             a.object_type AS ��������  ,
           to_char(a.created) AS ����ʱ��,
           to_char(a.last_ddl_time) AS ����޸�ʱ��
                  
    FROM 
    USER_OBJECTS a
  WHERE 
 a.object_type='FUNCTION'
    OR a.object_type='PACKAGE '
    or a.object_type='PROCEDURE'
 or a.object_type='SEQUENCE'
 or a.object_type='TABLE'

)
)
ORDER BY �������� DESC

--------------------------------------------------------------------------------------------------------

SELECT  
  a.TABLE_NAME  AS ����,
  (select comments from USER_TAB_COMMENTS where table_name= a.TABLE_NAME) AS 
��������,
  
  a.COLUMN_ID AS ���,
  a.COLUMN_NAME AS ƴ����,
  decode(
  (
      SELECT COUNT(*)       
      FROM    
      USER_CONS_COLUMNS aa,
      user_constraints bb
      WHERE 
      aa.owner=bb.owner AND 
      aa.table_name=bb.table_name AND
      aa.constraint_name=bb.constraint_name  AND 
      aa.table_name =a.TABLE_NAME AND 
      aa.column_name=a.COLUMN_NAME AND
      bb.constraint_type='P '
  ) ,'0','N','1','Y')   AS ����,
  decode(
  (
      SELECT COUNT(*)       
      FROM    
      USER_CONS_COLUMNS aa,
      user_constraints bb
      WHERE 
      aa.owner=bb.owner AND
      aa.table_name=bb.table_name AND
      aa.constraint_name=bb.constraint_name  AND 
      aa.table_name =a.TABLE_NAME AND 
      aa.column_name=a.COLUMN_NAME AND
      bb.constraint_type='C '
  ) ,'0','N','1','Y') AS ���,
  a.NULLABLE AS �Ƿ�Ϊ��,
  a.DATA_TYPE AS ��������,
  a.DATA_LENGTH AS ���ݳ���,
  a.DATA_PRECISION as ���ݾ���, 
  (
    SELECT comments FROM USER_COL_COMMENTS ss WHERE 
ss.table_name=a.TABLE_NAME AND ss.column_name=a.COLUMN_NAME
  ) AS ����������
  from   user_tab_columns   a
  where a.TABLE_NAME='DGB02'
  order by a.COLUMN_ID
