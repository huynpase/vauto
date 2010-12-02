using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Vibz.Reflection
{
    public class Runtime
    {
        public static object CreateInstanceAndInitialize(Assembly assembly, string className, string initializingFunction, object[] param)
        {
            object obj = assembly.CreateInstance(className, true);
            obj.GetType().InvokeMember(initializingFunction, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, param);
            return obj;
        }
        public static object CreateInstanceAndInitialize(string assemblyPath, string className, string initializingFunction, object[] param)
        {
            object obj = Activator.CreateInstance(GetType(Assembly.GetCallingAssembly().Location, assemblyPath, className));
            obj.GetType().InvokeMember(initializingFunction, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, param);
            return obj;
        }
        public static object CreateInstanceAndInitialize(string assemblyPath, string className, object[] param)
        {
            return CreateInstanceAndInitialize(assemblyPath, className, "Init", param);
        }
        public static object CreateInstance(string assemblyPath, string className)
        {
            return Activator.CreateInstance(GetType(assemblyPath, className));
        }
        public static object CreateInstance(string assemblyPath, string className, object[] param)
        {
            return Activator.CreateInstance(GetType(assemblyPath, className), param);
        }
        public static Type GetType(string assemblyPath, string className)
        {
            return GetAssembly(assemblyPath).GetType(className, false, true);
        }
        public static Type GetType(string basePath, string assemblyPath, string className)
        {
            return GetAssembly(basePath, assemblyPath).GetType(className, false, true);
        }
        public static Assembly GetAssembly(string assemblyPath)
        {
            string asmPath = GetAbsolutePath(assemblyPath);
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(asmPath);
            return Assembly.Load(assemblyName);
        }
        public static Assembly GetAssembly(string basePath, string assemblyPath)
        {
            string asmPath = GetAbsolutePath(basePath, assemblyPath);
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(asmPath);
            return Assembly.Load(assemblyName);
        }
        public static Assembly LoadAssemblyIntoTemporaryDomain(string assembly)
        {
            string directory = Vibz.Reflection.Runtime.GetAbsolutePath("VibzDomain");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string srcFile = Vibz.Reflection.Runtime.GetAbsolutePath(assembly);

            byte[] b = File.ReadAllBytes(srcFile);
            return Assembly.Load(b);
        }
        public static string GetAbsolutePath(string relativePath)
        {
            return GetAbsolutePath(Assembly.GetExecutingAssembly().Location, relativePath);
        }
        public static string GetAbsolutePath(string basePath, string relativePath)
        {
            if (!File.Exists(basePath))
                throw new Exception("Invalid basePath '" + basePath + "'");
            if (relativePath == "")
                return "";
            Uri uri = new Uri(new Uri(basePath), relativePath);
            string retValue = uri.AbsolutePath;
            if (File.Exists(uri.AbsolutePath))
                return uri.AbsolutePath;
            return uri.LocalPath;
        }
    }
}
