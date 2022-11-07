using System;

namespace DesignPatterns
{
    public sealed class Singleton 
    {
        private Singleton() {}
        private static Singleton _instance;

        public static Singleton GetInstance() {
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }

        public void DoAction() {
            // ...
        }
    }

    public sealed class SimpleThreadSafeSingleton
    {
        private SimpleThreadSafeSingleton() {}
        private static SimpleThreadSafeSingleton _instance;
        private static readonly object _lock = new object();

        public static SimpleThreadSafeSingleton GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null) {
                    _instance = new SimpleThreadSafeSingleton()
                }
                
                return _instance;
            }
        }

        public void DoAction() {
            // ...
        }
    }

    public sealed class DoubleCheckLockingSingleton
    {
        private DoubleCheckLockingSingleton() {}
        private static DoubleCheckLockingSingleton _instance;
        private static readonly object _lock = new object();

        public static DoubleCheckLockingSingleton GetInstance()
        {
            if (_instance == null) {
                lock (_lock)
                {
                    if (_instance == null) {
                        _instance = new DoubleCheckLockingSingleton()
                    }
                }
            }

            return _instance;
        }

        public void DoAction() {
            // ...
        }
    }

    public class Logger 
    {
        private Logger() {}
        private static Logger _instance;
        private static readonly object _lock = new object();

        public static Logger GetInstance() {
            if (_instance == null) {
                lock (_lock)
                {
                    if (_instance == null) {
                        _instance = new Logger();
                    }
                }
            }

            return _instance;
        }

        public void LogError(Exception e) {}
    }
}