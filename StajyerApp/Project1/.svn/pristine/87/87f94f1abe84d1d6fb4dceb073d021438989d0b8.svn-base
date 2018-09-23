using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StajyerApp.Dal.DataErisim
{
    public class SQLManager
    {
        private static SqlConnection cnn = null;
        private static SqlCommand cmd = null;
        private static SqlTransaction myTransaction = null;

        private static bool transactionStatus = false;

        public void Clear()
        {
            if (transactionStatus == false)
            {
                cnn.Close();
                SQLConnection.ConnectionClose(cnn);
                if (cmd != null)
                {
                    cmd = null;
                }
            }
        }

        public static void ClearX()
        {
            if (transactionStatus == false)
            {
                cnn.Close();
                SQLConnection.ConnectionClose(cnn);
                if (cmd != null)
                {
                    cmd = null;
                }
            }

            transactionStatus = false;
        }

        //Sayaç sıfırlanıncaya kadar Tranction Başlatılmıyor
        public static void TransactionStart()
        {
            transactionStatus = true;

            cnn = SQLConnection.GetConnection();
            if (cnn.State != ConnectionState.Open)
            {
                cnn.Open();
            }

            myTransaction = cnn.BeginTransaction();
        }

        public static void TransactionCommit()
        {
            myTransaction.Commit();
            transactionStatus = false;
            ClearX();
        }

        public static void TransactionRollback()
        {
            myTransaction.Rollback();
            transactionStatus = false;
            ClearX();
        }

        public static void TransactionClear()
        {
            myTransaction = null;
        }


        public SQLManager(string Text)
        {
            if (transactionStatus == false)
            {
                cnn = SQLConnection.GetConnection();
            }

            CommandCreate(Text);

        }

        public SQLManager(string Text, SqlConnection _cnn)
        {

            if (transactionStatus != true)
            {
                cnn = _cnn;
            }
            CommandCreate(Text);
        }
        public SQLManager(string Text, CommandType _cmdType)
        {
            if (transactionStatus != true)
            {
                cnn = SQLConnection.GetConnection();
            }

            CommandCreate(Text, _cmdType);
        }

        private void CommandCreate(string Text)
        {
            try
            {
                cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = Text;
                cmd.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }
        }
        private void CommandCreate(string Text, CommandType _cmdType)
        {
            try
            {
                cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = Text;
                cmd.CommandType = _cmdType;
            }
            catch (Exception se)
            {

                throw new Exception(se.Message);
            }
        }
        public SqlParameter ParameterAdd(string ParameterName, SqlDbType ParameterType, object ParameterValue)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Value = ParameterValue;
                prm.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public SqlParameter ParameterAdd(string ParameterName, SqlDbType ParameterType, object ParameterValue, int ParameterLength)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Value = ParameterValue;
                prm.Size = ParameterLength;
                prm.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public SqlParameter ParameterAddWithDirection(string ParameterName, SqlDbType ParameterType, ParameterDirection prmDirection, object ParameterValue)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Value = ParameterValue;
                prm.Direction = prmDirection;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public SqlParameter ParameterAddWithDirection(string ParameterName, SqlDbType ParameterType, ParameterDirection prmDirection, object ParameterValue, int ParameterLength)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Value = ParameterValue;
                prm.Size = ParameterLength;
                prm.Direction = prmDirection;
                prm.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public SqlParameter OutParameterAdd(string ParameterName, SqlDbType ParameterType)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public SqlParameter OutParameterAdd(string ParameterName, SqlDbType ParameterType, int ParameterLength)
        {
            SqlParameter prm = null;
            try
            {
                prm = new SqlParameter();
                prm.ParameterName = ParameterName;
                prm.SqlDbType = ParameterType;
                prm.Size = ParameterLength;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return prm;
        }
        public static object GetValueObject(SqlDataReader rdr, string Field)
        {
            object veri = null;
            try
            {
                if (DBNull.Value.Equals(rdr[Field]) == false)
                {
                    veri = rdr[Field];
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static string GetValueString(SqlDataReader rdr, string alan)
        {
            string veri = string.Empty;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetString(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static int GetValueInt32(SqlDataReader rdr, string alan)
        {
            int veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetInt32(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static long GetValueInt64(SqlDataReader rdr, string alan)
        {
            long veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetInt64(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static int GetValueInt16(SqlDataReader rdr, string alan)
        {
            int veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetInt16(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static bool GetValueBool(SqlDataReader rdr, string alan)
        {
            bool veri = false;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetBoolean(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static byte GetValueByte(SqlDataReader rdr, string alan)
        {
            byte veri = 0;

            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetByte(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static byte[] GetValueByteArray(SqlDataReader rdr, string alan)
        {
            byte[] dizi = null;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    try
                    {
                        dizi = (byte[])(rdr[index]);

                        if (dizi != null)
                        {
                            return dizi;
                        }
                    }
                    catch (Exception)
                    {
                        return dizi;
                    }

                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return dizi;
        }
        public static decimal GetValueDecimal(SqlDataReader rdr, string alan)
        {
            decimal veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetDecimal(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static double GetValueDouble(SqlDataReader rdr, string alan)
        {
            double veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetDouble(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static float GetValueFloat(SqlDataReader rdr, string alan)
        {
            float veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetFloat(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static TimeSpan GetValueObjectTimeSpan(SqlDataReader rdr, string alan)
        {
            TimeSpan veri = new TimeSpan();
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetTimeSpan(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static DateTime GetValueDateTime(SqlDataReader rdr, string alan)
        {
            DateTime veri = new DateTime();
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetDateTime(index);
                    return veri;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }
        public static DateTimeOffset GetValueDateTimeOffset(SqlDataReader rdr, string alan)
        {
            DateTimeOffset veri = new DateTimeOffset();
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetDateTimeOffset(index);
                    return veri;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }

        public static Single GetValueSingle(SqlDataReader rdr, string alan)
        {
            Single veri = -1;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetFloat(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }

        public static Guid GetValueGuid(SqlDataReader rdr, string alan)
        {
            Guid veri = Guid.Empty;
            try
            {
                int index = rdr.GetOrdinal(alan);
                if (!rdr.IsDBNull(index))
                {
                    veri = rdr.GetGuid(index);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return veri;
        }

        public object OutParameterGetValue(string ParameterName)
        {
            object deger = null;
            try
            {
                deger = cmd.Parameters[ParameterName].Value;
            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }

            return deger;
        }

        public int Execute()
        {
            int etkilenen = 0;
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }

                cmd.Transaction = myTransaction;
                etkilenen = cmd.ExecuteNonQuery();

                //cnn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);

            }
            return etkilenen;
        }




        public object ExecuteScalar()
        {
            object Result = null;
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }

                cmd.Transaction = myTransaction;

                Result = cmd.ExecuteScalar();
                //cnn.Close();
            }
            catch (SqlException se)
            {
                Result = null;
                throw new Exception(se.Message);
            }
            return Result;
        }
        public SqlDataReader ExecuteReader()
        {
            SqlDataReader sdr;
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                cmd.Transaction = myTransaction;
                sdr = cmd.ExecuteReader();
                //cnn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return sdr;
        }

        public DataTable ExecuteDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                //cnn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return dt;
        }

        public DataSet ExecuteDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                //cnn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return ds;
        }
        public int DataTableSave(DataTable dt)
        {
            int _Sonuc = 0;
            try
            {
                cnn.Open();
                SqlDataAdapter sql_adptr = new SqlDataAdapter(cmd);
                SqlCommandBuilder cmbKaydet = new SqlCommandBuilder(sql_adptr);
                _Sonuc = sql_adptr.Update(dt);
                //cnn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return _Sonuc;
        }
    }
}
