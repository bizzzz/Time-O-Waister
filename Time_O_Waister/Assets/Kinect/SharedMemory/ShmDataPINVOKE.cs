/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.8
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace de.dailab.interprocess.shm {

using System;
using System.Runtime.InteropServices;

class ShmDataPINVOKE {

  protected class SWIGExceptionHelper {

    public delegate void ExceptionDelegate(string message);
    public delegate void ExceptionArgumentDelegate(string message, string paramName);

    static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
    static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
    static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
    static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
    static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
    static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
    static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
    static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
    static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
    static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
    static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

    static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
    static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
    static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

#if DEBUG
    [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="SWIGRegisterExceptionCallbacks_ShmData")]
#else
    [DllImport("ShmRingBuffer_csharp", EntryPoint="SWIGRegisterExceptionCallbacks_ShmData")]
#endif
    public static extern void SWIGRegisterExceptionCallbacks_ShmData(
                                ExceptionDelegate applicationDelegate,
                                ExceptionDelegate arithmeticDelegate,
                                ExceptionDelegate divideByZeroDelegate, 
                                ExceptionDelegate indexOutOfRangeDelegate, 
                                ExceptionDelegate invalidCastDelegate,
                                ExceptionDelegate invalidOperationDelegate,
                                ExceptionDelegate ioDelegate,
                                ExceptionDelegate nullReferenceDelegate,
                                ExceptionDelegate outOfMemoryDelegate, 
                                ExceptionDelegate overflowDelegate, 
                                ExceptionDelegate systemExceptionDelegate);

#if DEBUG
    [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_ShmData")]
#else
    [DllImport("ShmRingBuffer_csharp", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_ShmData")]
#endif
    public static extern void SWIGRegisterExceptionCallbacksArgument_ShmData(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new System.ArgumentNullException(paramName, message));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
      SWIGRegisterExceptionCallbacks_ShmData(
                                applicationDelegate,
                                arithmeticDelegate,
                                divideByZeroDelegate,
                                indexOutOfRangeDelegate,
                                invalidCastDelegate,
                                invalidOperationDelegate,
                                ioDelegate,
                                nullReferenceDelegate,
                                outOfMemoryDelegate,
                                overflowDelegate,
                                systemDelegate);

      SWIGRegisterExceptionCallbacksArgument_ShmData(
                                argumentDelegate,
                                argumentNullDelegate,
                                argumentOutOfRangeDelegate);
    }
  }

  protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

  public class SWIGPendingException {
    [ThreadStatic]
    private static Exception pendingException = null;
    private static int numExceptionsPending = 0;

    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      } 
    }

    public static void Set(Exception e) {
      if (pendingException != null)
        throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(typeof(ShmDataPINVOKE)) {
        numExceptionsPending++;
      }
    }

    public static Exception Retrieve() {
      Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(typeof(ShmDataPINVOKE)) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }
  }


  protected class SWIGStringHelper {

    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

#if DEBUG
    [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="SWIGRegisterStringCallback_ShmData")]
#else
    [DllImport("ShmRingBuffer_csharp", EntryPoint="SWIGRegisterStringCallback_ShmData")]
#endif
    public static extern void SWIGRegisterStringCallback_ShmData(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_ShmData(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static ShmDataPINVOKE() {
  }


#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataRequest")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataRequest")]
#endif
  public static extern IntPtr new_DataRequest();

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_delete_DataRequest")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_delete_DataRequest")]
#endif
  public static extern void delete_DataRequest(HandleRef jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_remove_shm_with_name")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_remove_shm_with_name")]
#endif
  public static extern void remove_shm_with_name(string jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataWriter__SWIG_0")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataWriter__SWIG_0")]
#endif
  public static extern IntPtr new_DataWriter__SWIG_0(string jarg1, uint jarg2, uint jarg3, uint jarg4);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataWriter__SWIG_1")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataWriter__SWIG_1")]
#endif
  public static extern IntPtr new_DataWriter__SWIG_1(string jarg1, uint jarg2, uint jarg3);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataWriter__SWIG_2")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataWriter__SWIG_2")]
#endif
  public static extern IntPtr new_DataWriter__SWIG_2(string jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_delete_DataWriter")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_delete_DataWriter")]
#endif
  public static extern void delete_DataWriter(HandleRef jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataWriter_writeData")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataWriter_writeData")]
#endif
  public static extern void DataWriter_writeData(HandleRef jarg1, [In, MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, uint jarg3);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataWriter_writeDataBegin")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataWriter_writeDataBegin")]
#endif
  public static extern void DataWriter_writeDataBegin(HandleRef jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataWriter_writeDataContent")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataWriter_writeDataContent")]
#endif
  public static extern void DataWriter_writeDataContent(HandleRef jarg1, [In, MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, uint jarg3, uint jarg4);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataWriter_writeDataEnd")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataWriter_writeDataEnd")]
#endif
  public static extern void DataWriter_writeDataEnd(HandleRef jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataReader__SWIG_0")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataReader__SWIG_0")]
#endif
  public static extern IntPtr new_DataReader__SWIG_0(string jarg1, uint jarg2, uint jarg3, uint jarg4);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataReader__SWIG_1")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataReader__SWIG_1")]
#endif
  public static extern IntPtr new_DataReader__SWIG_1(string jarg1, uint jarg2, uint jarg3);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_new_DataReader__SWIG_2")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_new_DataReader__SWIG_2")]
#endif
  public static extern IntPtr new_DataReader__SWIG_2(string jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_delete_DataReader")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_delete_DataReader")]
#endif
  public static extern void delete_DataReader(HandleRef jarg1);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataReader_readData__SWIG_0")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataReader_readData__SWIG_0")]
#endif
  public static extern uint DataReader_readData__SWIG_0(HandleRef jarg1, [Out, MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, uint jarg3, int jarg4);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataReader_readData__SWIG_1")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataReader_readData__SWIG_1")]
#endif
  public static extern uint DataReader_readData__SWIG_1(HandleRef jarg1, [Out, MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, uint jarg3);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataReader_readData_unsafe__SWIG_0")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataReader_readData_unsafe__SWIG_0")]
#endif
  public static extern uint DataReader_readData_unsafe__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3, int jarg4);

#if DEBUG
  [DllImport("ShmRingBuffer_csharp_debug", EntryPoint="CSharp_DataReader_readData_unsafe__SWIG_1")]
#else
  [DllImport("ShmRingBuffer_csharp", EntryPoint="CSharp_DataReader_readData_unsafe__SWIG_1")]
#endif
  public static extern uint DataReader_readData_unsafe__SWIG_1(HandleRef jarg1, IntPtr jarg2, uint jarg3);
}

}
