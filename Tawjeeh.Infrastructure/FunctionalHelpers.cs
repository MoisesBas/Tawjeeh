using System;

namespace Tawjeeh.Infrastructure
{
    public static class FunctionalHelpers
    {
        
        public static void TryCatch<TE>(Action tryAction, Action<Exception> handler)
          where TE : Exception
        {
            try { tryAction(); }
            catch (TE ex)
            {
                handler(ex);
            }
        }

        
        public static void TryCatch<TArg, TE>(Action<TArg> tryAction, TArg args, Action<Exception> handler)
          where TE : Exception
        {
            try { tryAction(args); }
            catch (TE ex)
            {
                handler(ex);
            }
        }

        public static void TryCatchFinally<TE>(Action tryAction, Action<Exception> CatchAction, Action FinallyAction)
            where TE : Exception
        {
            try
            {
                tryAction();
            }
            catch (TE t)
            {
                CatchAction(t);
            }
            finally
            {
                FinallyAction();
            }
        }

       
        public static void TryCatch<T1>(Action tryAction, Action<Exception> handler, Action FinallyAction)
            where T1 : Exception
        {
            try
            {
                tryAction();
            }
            catch (T1 ex)
            {
                handler(ex);
            }
            finally
            {
                FinallyAction();
            }
        }

      
        public static void TryCatchFinally<T1, TF>(Action tryAction, Action<Exception> handler, Action<TF> finallyAction, TF FinallyArg)
            where T1 : Exception
        {
            try
            {
                tryAction();
            }
            catch (T1 ex)
            {
                handler(ex);
            }
            finally
            {
                finallyAction(FinallyArg);
            }
        }

    }
}
