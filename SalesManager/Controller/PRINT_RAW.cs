using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using DevExpress.XtraReports.Native;
using System.IO;

namespace SalesManager.Controller
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDataType;
    }
    public class PRINT_RAW
    {
        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);

        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern long StartPagePrinter(IntPtr hPrinter);

        //[DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern long EndPagePrinter(IntPtr hPrinter);

        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern long EndDocPrinter(IntPtr hPrinter);

        //[DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern long ClosePrinter(IntPtr hPrinter);
        //public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        //{
        //    Int32 dwError = 0, dwWritten = 0;
        //    IntPtr hPrinter = new IntPtr(0);
        //    DOCINFOA di = new DOCINFOA();
        //    bool bSuccess = false; // Assume failure unless you specifically succeed.

        //    di.pDocName = "My C#.NET RAW Document";
        //    di.pDataType = "RAW";

        //    // Open the printer.
        //    if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
        //    {
        //        // Start a document.
        //        if (StartDocPrinter(hPrinter, 1, di))
        //        {
        //            // Start a page.
        //            if (StartPagePrinter(hPrinter))
        //            {
        //                // Write your bytes.
        //                bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
        //                EndPagePrinter(hPrinter);
        //            }
        //            EndDocPrinter(hPrinter);
        //        }
        //        ClosePrinter(hPrinter);
        //    }
        //    // If you did not succeed, GetLastError may give more information
        //    // about why not.
        //    if (bSuccess == false)
        //    {
        //        dwError = Marshal.GetLastWin32Error();
        //    }
        //    return bSuccess;
        //}

        //public void Print_Raw_Data(string PrinterName, string Chuoistring)
        //{
        //    System.IntPtr lhPrinter = new System.IntPtr();

        //    DOCINFO di = new DOCINFO();
        //    int pcWritten = 0;
        //    di.pDocName = "MY DOCUMENT";
        //    di.pDataType = "RAW";

        //    //lhPrinter contains the handle for the printer opened
        //    //If lhPrinter is 0 then an error has occured
        //    OpenPrinter(PrinterName, ref lhPrinter, 0);
        //    StartDocPrinter(lhPrinter, 1, ref di);
        //    StartPagePrinter(lhPrinter);
        //    try
        //    {

        //        WritePrinter(lhPrinter, Chuoistring, Chuoistring.Length, ref pcWritten);

        //        // Send a form feed character to the printer
        //        //st1 = "\f";
        //        //PrintDirect.WritePrinter(lhPrinter, st1, st1.Length, ref pcWritten);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    EndPagePrinter(lhPrinter);
        //    EndDocPrinter(lhPrinter);
        //    ClosePrinter(lhPrinter);
        //}
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint="OpenPrinterA", SetLastError=true, CharSet=CharSet.Ansi, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint="ClosePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="StartDocPrinterA", SetLastError=true, CharSet=CharSet.Ansi, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool StartDocPrinter( IntPtr hPrinter, Int32 level,  [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint="EndDocPrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="StartPagePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="EndPagePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="WritePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten );

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public  bool SendBytesToPrinter( string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32    dwError = 0, dwWritten = 0;
            IntPtr    hPrinter = new IntPtr(0);
            DOCINFOA    di = new DOCINFOA();
            bool    bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if( OpenPrinter( szPrinterName.Normalize(), out hPrinter, IntPtr.Zero ) )
            {
                // Start a document.
                if( StartDocPrinter(hPrinter, 1, di) )
                {
                    // Start a page.
                    if( StartPagePrinter(hPrinter) )
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if( bSuccess == false )
            {
                    dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public  bool SendFileToPrinter( string szPrinterName, string szFileName )
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte []bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes( nLength );
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public  bool SendStringToPrinter( string szPrinterName, string szString )
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
