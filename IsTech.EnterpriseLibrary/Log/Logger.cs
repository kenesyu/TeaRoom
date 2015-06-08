using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.IO;

using IsTech.EnterpriseLibrary.Simulate;
namespace IsTech.EnterpriseLibrary.Log
{
    #region enum
    public enum LogLevel
    {
        Debug, Message, Error
    }
    public enum RecLogType
    {
        File, EventLog
    }
    #endregion

    public class Logger
    {
        public Logger()
        {
        }
        protected const string SysFileDir = @"C:\Temp";
        protected const string SysFileName = "AFGPMException.log";
        protected const string DefaultLogFileName = @"c:\Temp\AFGPMLogException.log";
        protected const string SysEventName = "AFGPPV";



        #region Property
        private string FileDir = string.Empty;
        private string FileName = string.Empty;
        #endregion

        #region Public NewLog
        public void NewLog(Exception ex)
        {
            NewLog(ex, LogLevel.Error);
        }
        public void NewLog(Exception ex, LogLevel logLevel)
        {
            NewLog(ex, logLevel, RecLogType.EventLog);
        }
        public void NewLog(Exception ex, LogLevel logLevel, RecLogType recLogType)
        {
            NewLog(ex, logLevel, recLogType, string.Empty);
        }
        public void NewLog(Exception ex, LogLevel logLevel, RecLogType recLogType, string filePath)
        {
            NewLog(ex, logLevel, recLogType, filePath, string.Empty);
        }
        public void NewLog(Exception ex, LogLevel logLevel, RecLogType recLogType, string filePath, string fileName)
        {
            AddLog(ex.Message, logLevel, recLogType, filePath, fileName);
        }
        public void NewLog(string message)
        {
            NewLog(message, LogLevel.Error);
        }
        public void NewLog(string message, LogLevel logLevel)
        {
            NewLog(message, logLevel, RecLogType.EventLog);
        }
        public void NewLog(string message, LogLevel logLevel, RecLogType recLogType)
        {
            NewLog(message, logLevel, recLogType, string.Empty);
        }
        public void NewLog(string message, LogLevel logLevel, RecLogType recLogType, string filePath)
        {
            NewLog(message, logLevel, recLogType, filePath, string.Empty);
        }
        public void NewLog(string message, LogLevel logLevel, RecLogType recLogType, string filePath, string fileName)
        {
            AddLog(message, logLevel, recLogType, filePath, fileName);
        }
        #endregion

        #region Private Method
        private void AddLog(string message, LogLevel logLevel, RecLogType recLogType, string filePath, string fileName)
        {
            if (filePath == string.Empty)
            {
                FileDir = SysFileDir;
            }
            else
            {
                FileDir = filePath;
            }

            if (fileName == string.Empty)
            {
                FileName = SysFileName;
            }
            else
            {
                FileName = fileName;
            }

            if (recLogType == RecLogType.File)
            {
                WriteToFile(message, logLevel);
            }
            else
            {
                WriteToEventLog(message, logLevel);
            }
        }
        private string GetLogFile()
        {
            if (!Directory.Exists(this.FileDir))
            {
                Directory.CreateDirectory(this.FileDir);
            }

            DirectoryInfo di = new DirectoryInfo(this.FileDir);
            bool flag = true;
            int index = 0;
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(this.FileDir);
            sb.Append(@"\");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            sb.Append(@"-");

            while (flag)
            {
                index = index + 1;
                result = sb.ToString() + index.ToString("000") + @"-" + this.FileName;
                if (!File.Exists(result))
                {
                    StreamWriter sw = System.IO.File.CreateText(result);
                    sw.Close();
                    flag = false;
                }
                else
                {
                    FileInfo fi = new FileInfo(result);
                    if (fi.Length < 511 * 1024)
                    {
                        flag = false;
                    }
                }
            }
            return result;
        }
        private void WriteToFile(string message, LogLevel logLevel)
        {
            try
            {
                string filename = GetLogFile();
                StreamWriter w = File.AppendText(filename);
                StringBuilder sb = new StringBuilder(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                sb.Append("    ");
                sb.Append(logLevel.ToString());
                sb.Append("    ");
                sb.Append(message);
                w.WriteLine(sb.ToString());
                w.Flush();
                w.Close();
            }
            catch (Exception ex)
            {
                StreamWriter w = File.AppendText(DefaultLogFileName);
                w.WriteLine(DateTime.Now.ToString() + "  " + ex.Message);
                w.Flush();
                w.Close();
            }

        }
        private void WriteToEventLog(string message, LogLevel logLevel)
        {

            IdentityAnalogue identityAnalogue = new IdentityAnalogue();
            string userName = ConfigurationManager.AppSettings["ImpersonateUserName"];
            string passWord = ConfigurationManager.AppSettings["ImpersonateUserPassWord"];
            if (identityAnalogue.ImpersonateValidUser(userName, string.Empty, passWord))
            {
                if (!EventLog.SourceExists(SysEventName))
                {
                    EventLog.CreateEventSource(SysEventName, SysEventName + "Log");
                }
                EventLogEntryType type;
                if (logLevel == LogLevel.Error)
                {
                    type = EventLogEntryType.Error;
                }
                else if (logLevel == LogLevel.Debug)
                {
                    type = EventLogEntryType.Warning;
                }
                else
                {
                    type = EventLogEntryType.Information;
                }
                EventLog.WriteEntry(SysEventName, message, type);
            }
            identityAnalogue.UndoImpersonation();
        }
        #endregion
    }
}
