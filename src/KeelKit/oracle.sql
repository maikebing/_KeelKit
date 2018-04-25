
-----------表------------------------------------------------------
SELECT

  a.TABLE_NAME  AS 表名,
 -- a.COLUMN_ID AS 序号,
  a.COLUMN_NAME AS 拼音码,
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
  ) ,'0','N','1','Y')   AS 主键,
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
  ) ,'0','N','1','Y') AS 外键,
  a.NULLABLE AS 是否为空,
  a.DATA_TYPE AS 数据类型,
  a.DATA_LENGTH AS 数据长度,
  -- a.AS < http://a.as/> 小数位数,
  (
    SELECT comments FROM USER_COL_COMMENTS ss WHERE 
ss.table_name=a.TABLE_NAME AND ss.column_name=a.COLUMN_NAME
  ) AS 数据项描述
  from   user_tab_columns   a

 

---数据库对象---------------------------------------------------------------------------

SELECT * FROM
(
(SELECT
   a.object_type||'合计:' AS 对象名称,
   to_char( COUNT(*))||'个' AS 说明,
    '合计' AS 对象类型,
    '-' AS 创建时间,
    '-' AS 最后修改时间
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
           a.object_name AS 对象名称,           
           (select comments from USER_TAB_COMMENTS where 
table_name=a.object_name) AS 说明,
             a.object_type AS 对象类型  ,
           to_char(a.created) AS 创建时间,
           to_char(a.last_ddl_time) AS 最后修改时间
                  
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
ORDER BY 对象类型 DESC

--------------------------------------------------------------------------------------------------------

SELECT  
  a.TABLE_NAME  AS 表名,
  (select comments from USER_TAB_COMMENTS where table_name= a.TABLE_NAME) AS 
表中文名,
  
  a.COLUMN_ID AS 序号,
  a.COLUMN_NAME AS 拼音码,
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
  ) ,'0','N','1','Y')   AS 主键,
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
  ) ,'0','N','1','Y') AS 外键,
  a.NULLABLE AS 是否为空,
  a.DATA_TYPE AS 数据类型,
  a.DATA_LENGTH AS 数据长度,
  a.DATA_PRECISION as 数据精度, 
  (
    SELECT comments FROM USER_COL_COMMENTS ss WHERE 
ss.table_name=a.TABLE_NAME AND ss.column_name=a.COLUMN_NAME
  ) AS 数据项描述
  from   user_tab_columns   a
  where a.TABLE_NAME='DGB02'
  order by a.COLUMN_ID
