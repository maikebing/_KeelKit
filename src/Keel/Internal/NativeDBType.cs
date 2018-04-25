using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace Keel
{

    internal class NativeOledbWrapper
    {
        // Fields
        internal static int SizeOfPROPVARIANT = 0x10;

    }


    internal abstract class DbBuffer : SafeHandle
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern int lstrlenW(IntPtr ptr);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LocalFree(IntPtr handle);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LocalAlloc(int flags, IntPtr countOfBytes);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll")]
        internal static extern void ZeroMemory(IntPtr dest, IntPtr length);
 


        // Fields
        private readonly int _bufferLength;
        internal const int LMEM_FIXED = 0;
        internal const int LMEM_MOVEABLE = 2;
        internal const int LMEM_ZEROINIT = 0x40;

        // Methods
        protected DbBuffer(int initialSize)
            : this(initialSize, true)
        {
        }

        protected DbBuffer(int initialSize, bool zeroBuffer)
            : base(IntPtr.Zero, true)
        {
            if (0 < initialSize)
            {
                int flags = zeroBuffer ? 0x40 : 0;
                this._bufferLength = initialSize;
                RuntimeHelpers.PrepareConstrainedRegions();
                try
                {
                }
                finally
                {
                    base.handle = LocalAlloc(flags, (IntPtr)initialSize);
                }
                if (IntPtr.Zero == base.handle)
                {
                    throw new OutOfMemoryException();
                }
            }
        }

        protected DbBuffer(IntPtr invalidHandleValue, bool ownsHandle)
            : base(invalidHandleValue, ownsHandle)
        {
        }

        internal string PtrToStringUni(int offset)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2);
            string str = null;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr ptr = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                int len = lstrlenW(ptr);
                this.Validate(offset, 2 * (len + 1));
                str = Marshal.PtrToStringUni(ptr, len);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return str;
        }

        internal string PtrToStringUni(int offset, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2 * length);
            string str = null;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                str = Marshal.PtrToStringUni(ADP.IntPtrOffset(base.DangerousGetHandle(), offset), length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return str;
        }

        internal byte ReadByte(int offset)
        {
            byte num;
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                num = Marshal.ReadByte(base.DangerousGetHandle(), offset);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return num;
        }

        internal byte[] ReadBytes(int offset, int length)
        {
            byte[] destination = new byte[length];
            return this.ReadBytes(offset, destination, 0, length);
        }

        internal byte[] ReadBytes(int offset, byte[] destination, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.Copy(ADP.IntPtrOffset(base.DangerousGetHandle(), offset), destination, startIndex, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return destination;
        }

        internal char ReadChar(int offset)
        {
            return (char)((ushort)this.ReadInt16(offset));
        }

        internal char[] ReadChars(int offset, char[] destination, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.Copy(ADP.IntPtrOffset(base.DangerousGetHandle(), offset), destination, startIndex, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return destination;
        }

        internal DateTime ReadDate(int offset)
        {
            short[] destination = new short[3];
            this.ReadInt16Array(offset, destination, 0, 3);
            return new DateTime((ushort)destination[0], (ushort)destination[1], (ushort)destination[2]);
        }

        internal DateTime ReadDateTime(int offset)
        {
            short[] destination = new short[6];
            this.ReadInt16Array(offset, destination, 0, 6);
            int num = this.ReadInt32(offset + 12);
            DateTime time = new DateTime((ushort)destination[0], (ushort)destination[1], (ushort)destination[2], (ushort)destination[3], (ushort)destination[4], (ushort)destination[5]);
            return time.AddTicks((long)(num / 100));
        }

        internal double ReadDouble(int offset)
        {
            return BitConverter.Int64BitsToDouble(this.ReadInt64(offset));
        }

        internal Guid ReadGuid(int offset)
        {
            byte[] destination = new byte[0x10];
            this.ReadBytes(offset, destination, 0, 0x10);
            return new Guid(destination);
        }

        internal short ReadInt16(int offset)
        {
            short num;
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                num = Marshal.ReadInt16(base.DangerousGetHandle(), offset);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return num;
        }

        internal void ReadInt16Array(int offset, short[] destination, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.Copy(ADP.IntPtrOffset(base.DangerousGetHandle(), offset), destination, startIndex, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal int ReadInt32(int offset)
        {
            int num;
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                num = Marshal.ReadInt32(base.DangerousGetHandle(), offset);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return num;
        }

        internal void ReadInt32Array(int offset, int[] destination, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 4 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.Copy(ADP.IntPtrOffset(base.DangerousGetHandle(), offset), destination, startIndex, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal long ReadInt64(int offset)
        {
            long num;
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                num = Marshal.ReadInt64(base.DangerousGetHandle(), offset);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return num;
        }

        internal IntPtr ReadIntPtr(int offset)
        {
            IntPtr ptr;
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                ptr = Marshal.ReadIntPtr(base.DangerousGetHandle(), offset);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
            return ptr;
        }

        internal decimal ReadNumeric(int offset)
        {
            byte[] destination = new byte[20];
            this.ReadBytes(offset, destination, 1, 0x13);
            int[] bits = new int[4];
            bits[3] = destination[2] << 0x10;
            if (destination[3] == 0)
            {
                bits[3] |= -2147483648;
            }
            bits[0] = BitConverter.ToInt32(destination, 4);
            bits[1] = BitConverter.ToInt32(destination, 8);
            bits[2] = BitConverter.ToInt32(destination, 12);
            if (BitConverter.ToInt32(destination, 0x10) != 0)
            {
                //throw ADP.NumericToDecimalOverflow();
            }
            return new decimal(bits);
        }

        //internal   float ReadSingle(int offset)
        //{
        //    return  this.ReadInt32(offset)));
        //}

        internal TimeSpan ReadTime(int offset)
        {
            short[] destination = new short[3];
            this.ReadInt16Array(offset, destination, 0, 3);
            return new TimeSpan((ushort)destination[0], (ushort)destination[1], (ushort)destination[2]);
        }

        protected override bool ReleaseHandle()
        {
            IntPtr handle = base.handle;
            base.handle = IntPtr.Zero;
            if (IntPtr.Zero != handle)
            {
                LocalFree(handle);
            }
            return true;
        }

        private void StructureToPtr(int offset, object structure)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr ptr = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                Marshal.StructureToPtr(structure, ptr, false);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        protected void Validate(int offset, int count)
        {
            if (((offset < 0) || (count < 0)) || (this.Length < (offset + count)))
            {
                throw ADP.InternalError(ADP.InternalErrorCode.InvalidBuffer);
            }
        }

        [Conditional("DEBUG")]
        protected void ValidateCheck(int offset, int count)
        {
            this.Validate(offset, count);
        }

        internal void WriteByte(int offset, byte value)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.WriteByte(base.DangerousGetHandle(), offset, value);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteBytes(int offset, byte[] source, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr destination = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                Marshal.Copy(source, startIndex, destination, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteCharArray(int offset, char[] source, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr destination = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                Marshal.Copy(source, startIndex, destination, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteDate(int offset, DateTime value)
        {
            short[] source = new short[] { (short)value.Year, (short)value.Month, (short)value.Day };
            this.WriteInt16Array(offset, source, 0, 3);
        }

        internal void WriteDateTime(int offset, DateTime value)
        {
            int num = ((int)(value.Ticks % 0x989680L)) * 100;
            short[] source = new short[] { (short)value.Year, (short)value.Month, (short)value.Day, (short)value.Hour, (short)value.Minute, (short)value.Second };
            this.WriteInt16Array(offset, source, 0, 6);
            this.WriteInt32(offset + 12, num);
        }

        internal void WriteDouble(int offset, double value)
        {
            this.WriteInt64(offset, BitConverter.DoubleToInt64Bits(value));
        }

        internal void WriteGuid(int offset, Guid value)
        {
            this.StructureToPtr(offset, value);
        }

        internal void WriteInt16(int offset, short value)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.WriteInt16(base.DangerousGetHandle(), offset, value);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteInt16Array(int offset, short[] source, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 2 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr destination = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                Marshal.Copy(source, startIndex, destination, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteInt32(int offset, int value)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.WriteInt32(base.DangerousGetHandle(), offset, value);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteInt32Array(int offset, int[] source, int startIndex, int length)
        {
            offset += this.BaseOffset;
            this.Validate(offset, 4 * length);
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                IntPtr destination = ADP.IntPtrOffset(base.DangerousGetHandle(), offset);
                Marshal.Copy(source, startIndex, destination, length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteInt64(int offset, long value)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.WriteInt64(base.DangerousGetHandle(), offset, value);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteIntPtr(int offset, IntPtr value)
        {
            offset += this.BaseOffset;
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                Marshal.WriteIntPtr(base.DangerousGetHandle(), offset, value);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        internal void WriteNumeric(int offset, decimal value, byte precision)
        {
            int[] bits = decimal.GetBits(value);
            byte[] dst = new byte[20];
            dst[1] = precision;
            Buffer.BlockCopy(bits, 14, dst, 2, 2);
            dst[3] = (dst[3] == 0) ? ((byte)1) : ((byte)0);
            Buffer.BlockCopy(bits, 0, dst, 4, 12);
            dst[0x10] = 0;
            dst[0x11] = 0;
            dst[0x12] = 0;
            dst[0x13] = 0;
            this.WriteBytes(offset, dst, 1, 0x13);
        }

        //internal   void WriteSingle(int offset, float value)
        //{
        //    this.WriteInt32(offset, *((int*)&value));
        //}

        internal void WriteTime(int offset, TimeSpan value)
        {
            short[] source = new short[] { (short)value.Hours, (short)value.Minutes, (short)value.Seconds };
            this.WriteInt16Array(offset, source, 0, 3);
        }

        internal void ZeroMemory()
        {
            bool success = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                base.DangerousAddRef(ref success);
                ZeroMemory(base.DangerousGetHandle(), (IntPtr)this.Length);
            }
            finally
            {
                if (success)
                {
                    base.DangerousRelease();
                }
            }
        }

        // Properties
        private int BaseOffset
        {
            get
            {
                return 0;
            }
        }

        public override bool IsInvalid
        {
            get
            {
                return (IntPtr.Zero == base.handle);
            }
        }

        internal int Length
        {
            get
            {
                return this._bufferLength;
            }
        }
    }





    internal sealed class StringMemHandle : DbBuffer
    {
        // Methods
        internal StringMemHandle(string value)
            : base((value != null) ? (2 + (2 * value.Length)) : 0)
        {
            if (value != null)
            {
                base.WriteCharArray(0, value.ToCharArray(), 0, value.Length);
            }
        }
    }



    internal sealed class NativeDBType
    {
        // Fields
        internal const short ARRAY = 0x2000;
        internal const short BOOL = 11;
        internal const short BSTR = 8;
        internal const short BYREF = 0x4000;
        internal const short BYTES = 0x80;
        internal const short CY = 6;
          static readonly NativeDBType D_BigInt = new NativeDBType(0x13, 8, true, false, OleDbType.BigInt, 20, "DBTYPE_I8", typeof(long), 20, DbType.Int64);
        private static readonly NativeDBType D_Binary = new NativeDBType(0xff, -1, true, false, OleDbType.Binary, 0x80, "DBTYPE_BINARY", typeof(byte[]), 0x80, DbType.Binary);
        private static readonly NativeDBType D_Boolean = new NativeDBType(0xff, 2, true, false, OleDbType.Boolean, 11, "DBTYPE_BOOL", typeof(bool), 11, DbType.Boolean);
        private static readonly NativeDBType D_BSTR = new NativeDBType(0xff, ADP.PtrSize, false, false, OleDbType.BSTR, 8, "DBTYPE_BSTR", typeof(string), 8, DbType.String);
        private static readonly NativeDBType D_Chapter = new NativeDBType(0xff, ADP.PtrSize, false, false, OleDbType.Empty, 0x88, "DBTYPE_UDT", typeof(IDataReader), 0x88, DbType.Object);
        private static readonly NativeDBType D_Char = new NativeDBType(0xff, -1, true, false, OleDbType.Char, 0x81, "DBTYPE_CHAR", typeof(string), 130, DbType.AnsiStringFixedLength);
        private static readonly NativeDBType D_Currency = new NativeDBType(0x13, 8, true, false, OleDbType.Currency, 6, "DBTYPE_CY", typeof(decimal), 6, DbType.Currency);
        private static readonly NativeDBType D_Date = new NativeDBType(0xff, 8, true, false, OleDbType.Date, 7, "DBTYPE_DATE", typeof(DateTime), 7, DbType.DateTime);
        private static readonly NativeDBType D_DBDate = new NativeDBType(0xff, 6, true, false, OleDbType.DBDate, 0x85, "DBTYPE_DBDATE", typeof(DateTime), 0x85, DbType.Date);
        private static readonly NativeDBType D_DBTime = new NativeDBType(0xff, 6, true, false, OleDbType.DBTime, 0x86, "DBTYPE_DBTIME", typeof(TimeSpan), 0x86, DbType.Time);
        private static readonly NativeDBType D_DBTimeStamp = new NativeDBType(0xff, 0x10, true, false, OleDbType.DBTimeStamp, 0x87, "DBTYPE_DBTIMESTAMP", typeof(DateTime), 0x87, DbType.DateTime);
        private static readonly NativeDBType D_Decimal = new NativeDBType(0x1c, 0x10, true, false, OleDbType.Decimal, 14, "DBTYPE_DECIMAL", typeof(decimal), 14, DbType.Decimal);
        private static readonly NativeDBType D_Double = new NativeDBType(15, 8, true, false, OleDbType.Double, 5, "DBTYPE_R8", typeof(double), 5, DbType.Double);
        private static readonly NativeDBType D_Empty = new NativeDBType(0xff, 0, false, false, OleDbType.Empty, 0, "", null, 0, DbType.Object);
        private static readonly NativeDBType D_Error = new NativeDBType(0xff, 4, true, false, OleDbType.Error, 10, "DBTYPE_ERROR", typeof(int), 10, DbType.Int32);
        private static readonly NativeDBType D_Filetime = new NativeDBType(0xff, 8, true, false, OleDbType.Filetime, 0x40, "DBTYPE_FILETIME", typeof(DateTime), 0x40, DbType.DateTime);
        private static readonly NativeDBType D_Guid = new NativeDBType(0xff, 0x10, true, false, OleDbType.Guid, 0x48, "DBTYPE_GUID", typeof(Guid), 0x48, DbType.Guid);
        private static readonly NativeDBType D_IDispatch = new NativeDBType(0xff, ADP.PtrSize, true, false, OleDbType.IDispatch, 9, "DBTYPE_IDISPATCH", typeof(object), 9, DbType.Object);
        private static readonly NativeDBType D_Integer = new NativeDBType(10, 4, true, false, OleDbType.Integer, 3, "DBTYPE_I4", typeof(int), 3, DbType.Int32);
        private static readonly NativeDBType D_IUnknown = new NativeDBType(0xff, ADP.PtrSize, true, false, OleDbType.IUnknown, 13, "DBTYPE_IUNKNOWN", typeof(object), 13, DbType.Object);
        private static readonly NativeDBType D_LongVarBinary = new NativeDBType(0xff, -1, false, true, OleDbType.LongVarBinary, 0x80, "DBTYPE_LONGVARBINARY", typeof(byte[]), 0x80, DbType.Binary);
        private static readonly NativeDBType D_LongVarChar = new NativeDBType(0xff, -1, false, true, OleDbType.LongVarChar, 0x81, "DBTYPE_LONGVARCHAR", typeof(string), 130, DbType.AnsiString);
        private static readonly NativeDBType D_LongVarWChar = new NativeDBType(0xff, -1, false, true, OleDbType.LongVarWChar, 130, "DBTYPE_WLONGVARCHAR", typeof(string), 130, DbType.String);
        private static readonly NativeDBType D_Numeric = new NativeDBType(0x1c, 0x13, true, false, OleDbType.Numeric, 0x83, "DBTYPE_NUMERIC", typeof(decimal), 0x83, DbType.Decimal);
        private static readonly NativeDBType D_PropVariant = new NativeDBType(0xff, NativeOledbWrapper.SizeOfPROPVARIANT, true, false, OleDbType.PropVariant, 0x8a, "DBTYPE_PROPVARIANT", typeof(object), 12, DbType.Object);
        private static readonly NativeDBType D_Single = new NativeDBType(7, 4, true, false, OleDbType.Single, 4, "DBTYPE_R4", typeof(float), 4, DbType.Single);
        private static readonly NativeDBType D_SmallInt = new NativeDBType(5, 2, true, false, OleDbType.SmallInt, 2, "DBTYPE_I2", typeof(short), 2, DbType.Int16);
        private static readonly NativeDBType D_TinyInt = new NativeDBType(3, 1, true, false, OleDbType.TinyInt, 0x10, "DBTYPE_I1", typeof(short), 0x10, DbType.SByte);
        private static readonly NativeDBType D_Udt = new NativeDBType(0xff, -1, false, false, OleDbType.VarBinary, 0x84, "DBTYPE_BINARY", typeof(byte[]), 0x80, DbType.Binary);
        private static readonly NativeDBType D_UnsignedBigInt = new NativeDBType(20, 8, true, false, OleDbType.UnsignedBigInt, 0x15, "DBTYPE_UI8", typeof(decimal), 0x15, DbType.UInt64);
        private static readonly NativeDBType D_UnsignedInt = new NativeDBType(10, 4, true, false, OleDbType.UnsignedInt, 0x13, "DBTYPE_UI4", typeof(long), 0x13, DbType.UInt32);
        private static readonly NativeDBType D_UnsignedSmallInt = new NativeDBType(5, 2, true, false, OleDbType.UnsignedSmallInt, 0x12, "DBTYPE_UI2", typeof(int), 0x12, DbType.UInt16);
        private static readonly NativeDBType D_UnsignedTinyInt = new NativeDBType(3, 1, true, false, OleDbType.UnsignedTinyInt, 0x11, "DBTYPE_UI1", typeof(byte), 0x11, DbType.Byte);
        private static readonly NativeDBType D_VarBinary = new NativeDBType(0xff, -1, false, false, OleDbType.VarBinary, 0x80, "DBTYPE_VARBINARY", typeof(byte[]), 0x80, DbType.Binary);
        private static readonly NativeDBType D_VarChar = new NativeDBType(0xff, -1, false, false, OleDbType.VarChar, 0x81, "DBTYPE_VARCHAR", typeof(string), 130, DbType.AnsiString);
        private static readonly NativeDBType D_Variant = new NativeDBType(0xff, ODB.SizeOf_Variant, true, false, OleDbType.Variant, 12, "DBTYPE_VARIANT", typeof(object), 12, DbType.Object);
        private static readonly NativeDBType D_VarNumeric = new NativeDBType(0xff, 0x10, true, false, OleDbType.VarNumeric, 0x8b, "DBTYPE_VARNUMERIC", typeof(decimal), 14, DbType.VarNumeric);
        private static readonly NativeDBType D_VarWChar = new NativeDBType(0xff, -1, false, false, OleDbType.VarWChar, 130, "DBTYPE_WVARCHAR", typeof(string), 130, DbType.String);
        private static readonly NativeDBType D_WChar = new NativeDBType(0xff, -1, true, false, OleDbType.WChar, 130, "DBTYPE_WCHAR", typeof(string), 130, DbType.StringFixedLength);
        private static readonly NativeDBType D_Xml = new NativeDBType(0xff, -1, false, false, OleDbType.VarWChar, 0x8d, "DBTYPE_XML", typeof(string), 130, DbType.String);
        internal readonly string dataSourceType;
        internal readonly Type dataType;
        internal const short DATE = 7;
        internal const short DBDATE = 0x85;
        internal readonly int dbPart;
        internal readonly StringMemHandle dbString;
        internal const short DBTIME = 0x86;
        internal const short DBTIME_EX = 0x42;
        internal const short DBTIMESTAMP = 0x87;
        internal readonly short dbType;
        internal const short DBUTCDATETIME = 0x41;
        internal const short DECIMAL = 14;
        internal static readonly NativeDBType Default = D_VarWChar;
        internal const short EMPTY = 0;
        internal readonly DbType enumDbType;
        internal readonly OleDbType enumOleDbType;
        internal const short ERROR = 10;
        internal const short FILETIME = 0x40;
        private const int FixedDbPart = 5;
        internal readonly int fixlen;
        internal const short GUID = 0x48;
        internal const short HCHAPTER = 0x88;
        internal const short HighMask = -4096;
        internal const short I1 = 0x10;
        internal const short I2 = 2;
        internal const short I4 = 3;
        internal const short I8 = 20;
        internal const short IDISPATCH = 9;
        internal readonly bool isfixed;
        internal readonly bool islong;
        internal const short IUNKNOWN = 13;
        internal static readonly byte MaximumDecimalPrecision = D_Decimal.maxpre;
        internal readonly byte maxpre;
        internal const short NULL = 1;
        internal const short NUMERIC = 0x83;
        internal const short PROPVARIANT = 0x8a;
        internal const short R4 = 4;
        internal const short R8 = 5;
        internal const short RESERVED = -32768;
        private const string S_BINARY = "DBTYPE_BINARY";
        private const string S_BOOL = "DBTYPE_BOOL";
        private const string S_BSTR = "DBTYPE_BSTR";
        private const string S_CHAR = "DBTYPE_CHAR";
        private const string S_CY = "DBTYPE_CY";
        private const string S_DATE = "DBTYPE_DATE";
        private const string S_DBDATE = "DBTYPE_DBDATE";
        private const string S_DBTIME = "DBTYPE_DBTIME";
        private const string S_DBTIMESTAMP = "DBTYPE_DBTIMESTAMP";
        private const string S_DECIMAL = "DBTYPE_DECIMAL";
        private const string S_ERROR = "DBTYPE_ERROR";
        private const string S_FILETIME = "DBTYPE_FILETIME";
        private const string S_GUID = "DBTYPE_GUID";
        private const string S_I1 = "DBTYPE_I1";
        private const string S_I2 = "DBTYPE_I2";
        private const string S_I4 = "DBTYPE_I4";
        private const string S_I8 = "DBTYPE_I8";
        private const string S_IDISPATCH = "DBTYPE_IDISPATCH";
        private const string S_IUNKNOWN = "DBTYPE_IUNKNOWN";
        private const string S_LONGVARBINARY = "DBTYPE_LONGVARBINARY";
        private const string S_LONGVARCHAR = "DBTYPE_LONGVARCHAR";
        private const string S_NUMERIC = "DBTYPE_NUMERIC";
        private const string S_PROPVARIANT = "DBTYPE_PROPVARIANT";
        private const string S_R4 = "DBTYPE_R4";
        private const string S_R8 = "DBTYPE_R8";
        private const string S_UDT = "DBTYPE_UDT";
        private const string S_UI1 = "DBTYPE_UI1";
        private const string S_UI2 = "DBTYPE_UI2";
        private const string S_UI4 = "DBTYPE_UI4";
        private const string S_UI8 = "DBTYPE_UI8";
        private const string S_VARBINARY = "DBTYPE_VARBINARY";
        private const string S_VARCHAR = "DBTYPE_VARCHAR";
        private const string S_VARIANT = "DBTYPE_VARIANT";
        private const string S_VARNUMERIC = "DBTYPE_VARNUMERIC";
        private const string S_WCHAR = "DBTYPE_WCHAR";
        private const string S_WLONGVARCHAR = "DBTYPE_WLONGVARCHAR";
        private const string S_WVARCHAR = "DBTYPE_WVARCHAR";
        private const string S_XML = "DBTYPE_XML";
        internal const short STR = 0x81;
        internal const short UDT = 0x84;
        internal const short UI1 = 0x11;
        internal const short UI2 = 0x12;
        internal const short UI4 = 0x13;
        internal const short UI8 = 0x15;
        private const int VarblDbPart = 7;
        internal const short VARIANT = 12;
        internal const short VARNUMERIC = 0x8b;
        internal const short VECTOR = 0x1000;
        internal const short WSTR = 130;
        internal readonly short wType;
        internal const short XML = 0x8d;

        // Methods
        private NativeDBType(byte maxpre, int fixlen, bool isfixed, bool islong, OleDbType enumOleDbType, short dbType, string dbstring, Type dataType, short wType, DbType enumDbType)
        {
            this.enumOleDbType = enumOleDbType;
            this.dbType = dbType;
            this.dbPart = (-1 == fixlen) ? 7 : 5;
            this.isfixed = isfixed;
            this.islong = islong;
            this.maxpre = maxpre;
            this.fixlen = fixlen;
            this.wType = wType;
            this.dataSourceType = dbstring;
           // this.dbString = new StringMemHandle(dbstring);
            this.dataType = dataType;
            this.enumDbType = enumDbType;
        }

        internal static NativeDBType FromDataType(OleDbType enumOleDbType)
        {
            OleDbType type = enumOleDbType;
            if (type <= OleDbType.Filetime)
            {
                switch (type)
                {
                    case OleDbType.Empty:
                        return D_Empty;

                    case ((OleDbType)1):
                    case ((OleDbType)15):
                        goto Label_01BD;

                    case OleDbType.SmallInt:
                        return D_SmallInt;

                    case OleDbType.Integer:
                        return D_Integer;

                    case OleDbType.Single:
                        return D_Single;

                    case OleDbType.Double:
                        return D_Double;

                    case OleDbType.Currency:
                        return D_Currency;

                    case OleDbType.Date:
                        return D_Date;

                    case OleDbType.BSTR:
                        return D_BSTR;

                    case OleDbType.IDispatch:
                        return D_IDispatch;

                    case OleDbType.Error:
                        return D_Error;

                    case OleDbType.Boolean:
                        return D_Boolean;

                    case OleDbType.Variant:
                        return D_Variant;

                    case OleDbType.IUnknown:
                        return D_IUnknown;

                    case OleDbType.Decimal:
                        return D_Decimal;

                    case OleDbType.TinyInt:
                        return D_TinyInt;

                    case OleDbType.UnsignedTinyInt:
                        return D_UnsignedTinyInt;

                    case OleDbType.UnsignedSmallInt:
                        return D_UnsignedSmallInt;

                    case OleDbType.UnsignedInt:
                        return D_UnsignedInt;

                    case OleDbType.BigInt:
                        return D_BigInt;

                    case OleDbType.UnsignedBigInt:
                        return D_UnsignedBigInt;

                    case OleDbType.Filetime:
                        return D_Filetime;
                }
            }
            else
            {
                switch (type)
                {
                    case OleDbType.Binary:
                        return D_Binary;

                    case OleDbType.Char:
                        return D_Char;

                    case OleDbType.WChar:
                        return D_WChar;

                    case OleDbType.Numeric:
                        return D_Numeric;

                    case (OleDbType.Binary | OleDbType.Single):
                    case (OleDbType.Binary | OleDbType.BSTR):
                    case (OleDbType.Char | OleDbType.BSTR):
                        goto Label_01BD;

                    case OleDbType.DBDate:
                        return D_DBDate;

                    case OleDbType.DBTime:
                        return D_DBTime;

                    case OleDbType.DBTimeStamp:
                        return D_DBTimeStamp;

                    case OleDbType.PropVariant:
                        return D_PropVariant;

                    case OleDbType.VarNumeric:
                        return D_VarNumeric;

                    case OleDbType.Guid:
                        return D_Guid;

                    case OleDbType.VarChar:
                        return D_VarChar;

                    case OleDbType.LongVarChar:
                        return D_LongVarChar;

                    case OleDbType.VarWChar:
                        return D_VarWChar;

                    case OleDbType.LongVarWChar:
                        return D_LongVarWChar;

                    case OleDbType.VarBinary:
                        return D_VarBinary;

                    case OleDbType.LongVarBinary:
                        return D_LongVarBinary;
                }
            }
        Label_01BD:
            //  throw ODB.InvalidOleDbType(enumOleDbType);
            return D_Variant; ;
        }

        internal static NativeDBType FromDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                    return D_VarChar;

                case DbType.Binary:
                    return D_VarBinary;

                case DbType.Byte:
                    return D_UnsignedTinyInt;

                case DbType.Boolean:
                    return D_Boolean;

                case DbType.Currency:
                    return D_Currency;

                case DbType.Date:
                    return D_DBDate;

                case DbType.DateTime:
                    return D_DBTimeStamp;

                case DbType.Decimal:
                    return D_Decimal;

                case DbType.Double:
                    return D_Double;

                case DbType.Guid:
                    return D_Guid;

                case DbType.Int16:
                    return D_SmallInt;

                case DbType.Int32:
                    return D_Integer;

                case DbType.Int64:
                    return D_BigInt;

                case DbType.Object:
                    return D_Variant;

                case DbType.SByte:
                    return D_TinyInt;

                case DbType.Single:
                    return D_Single;

                case DbType.String:
                    return D_VarWChar;

                case DbType.Time:
                    return D_DBTime;

                case DbType.UInt16:
                    return D_UnsignedSmallInt;

                case DbType.UInt32:
                    return D_UnsignedInt;

                case DbType.UInt64:
                    return D_UnsignedBigInt;

                case DbType.VarNumeric:
                    return D_VarNumeric;

                case DbType.AnsiStringFixedLength:
                    return D_Char;

                case DbType.StringFixedLength:
                    return D_WChar;

                case DbType.Xml:
                    return D_Xml;
            }
            throw ADP.DbTypeNotSupported(dbType, typeof(OleDbType));
        }

        internal static NativeDBType FromDBType(short dbType, bool isLong, bool isFixed)
        {
            switch (dbType)
            {
                case 2:
                    return D_SmallInt;

                case 3:
                    return D_Integer;

                case 4:
                    return D_Single;

                case 5:
                    return D_Double;

                case 6:
                    return D_Currency;

                case 7:
                    return D_Date;

                case 8:
                    return D_BSTR;

                case 9:
                    return D_IDispatch;

                case 10:
                    return D_Error;

                case 11:
                    return D_Boolean;

                case 12:
                    return D_Variant;

                case 13:
                    return D_IUnknown;

                case 14:
                    return D_Decimal;

                case 0x10:
                    return D_TinyInt;

                case 0x11:
                    return D_UnsignedTinyInt;

                case 0x12:
                    return D_UnsignedSmallInt;

                case 0x13:
                    return D_UnsignedInt;

                case 20:
                    return D_BigInt;

                case 0x15:
                    return D_UnsignedBigInt;

                case 0x40:
                    return D_Filetime;

                case 0x80:
                    if (isLong)
                    {
                        return D_LongVarBinary;
                    }
                    if (isFixed)
                    {
                        return D_Binary;
                    }
                    return D_VarBinary;

                case 0x81:
                    if (isLong)
                    {
                        return D_LongVarChar;
                    }
                    if (isFixed)
                    {
                        return D_Char;
                    }
                    return D_VarChar;

                case 130:
                    if (isLong)
                    {
                        return D_LongVarWChar;
                    }
                    if (isFixed)
                    {
                        return D_WChar;
                    }
                    return D_VarWChar;

                case 0x83:
                    return D_Numeric;

                case 0x84:
                    return D_Udt;

                case 0x85:
                    return D_DBDate;

                case 0x86:
                    return D_DBTime;

                case 0x87:
                    return D_DBTimeStamp;

                case 0x88:
                    return D_Chapter;

                case 0x8a:
                    return D_PropVariant;

                case 0x8b:
                    return D_VarNumeric;

                case 0x8d:
                    return D_Xml;

                case 0x48:
                    return D_Guid;
            }
            if ((0x1000 & dbType) != 0)
            {
                throw ODB.DBBindingGetVector();
            }
            return D_Variant;
        }

        internal static NativeDBType FromSystemType(object value)
        {
            IConvertible convertible = value as IConvertible;
            if (convertible == null)
            {
                if (value is byte[])
                {
                    return D_VarBinary;
                }
                if (value is Guid)
                {
                    return D_Guid;
                }
                if (value is TimeSpan)
                {
                    return D_DBTime;
                }
                return D_Variant;
            }
            switch (convertible.GetTypeCode())
            {
                case TypeCode.Empty:
                    return D_Empty;

                case TypeCode.Object:
                    return D_Variant;

                case TypeCode.DBNull:
                    return D_Variant;

                case TypeCode.Boolean:
                    return D_Boolean;

                case TypeCode.Char:
                    return D_Char;

                case TypeCode.SByte:
                    return D_TinyInt;

                case TypeCode.Byte:
                    return D_UnsignedTinyInt;

                case TypeCode.Int16:
                    return D_SmallInt;

                case TypeCode.UInt16:
                    return D_UnsignedSmallInt;

                case TypeCode.Int32:
                    return D_Integer;

                case TypeCode.UInt32:
                    return D_UnsignedInt;

                case TypeCode.Int64:
                    return D_BigInt;

                case TypeCode.UInt64:
                    return D_UnsignedBigInt;

                case TypeCode.Single:
                    return D_Single;

                case TypeCode.Double:
                    return D_Double;

                case TypeCode.Decimal:
                    return D_Decimal;

                case TypeCode.DateTime:
                    return D_DBTimeStamp;

                case TypeCode.String:
                    return D_VarWChar;
            }
            return  D_Variant ;
           // throw ADP.UnknownDataTypeCode(value.GetType(), convertible.GetTypeCode());
        }

        internal static bool HasHighBit(short value)
        {
            return (0 != (-4096 & value));
        }

        // Properties
        internal bool IsVariableLength
        {
            get
            {
                return (-1 == this.fixlen);
            }
        }
    }





}
