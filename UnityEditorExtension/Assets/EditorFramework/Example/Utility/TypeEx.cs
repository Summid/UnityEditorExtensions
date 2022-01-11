using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace EditorFramework
{
    public static class TypeEx
    {
        /// <summary>
        /// 获取程序集中某个类的子类
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()//获取所有程序集
                .SelectMany(assembly => assembly.GetTypes())//将每个程序集中所有Type对象提取出来
                .Where(type => type.IsSubclassOf(self));//获取self类型的子类
        }

        /// <summary>
        /// 获取程序集中某个类的子类，并且该子类被某个特性所标记
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssemblies<T>(this Type self) where T : Attribute
        {
            return GetSubTypesInAssemblies(self)
                .Where(type => type.GetCustomAttribute<T>() != null);
        }
    }

}
