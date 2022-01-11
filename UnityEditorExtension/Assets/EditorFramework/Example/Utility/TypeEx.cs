using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace EditorFramework
{
    public static class TypeEx
    {
        /// <summary>
        /// ��ȡ������ĳ���������
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()//��ȡ���г���
                .SelectMany(assembly => assembly.GetTypes())//��ÿ������������Type������ȡ����
                .Where(type => type.IsSubclassOf(self));//��ȡself���͵�����
        }

        /// <summary>
        /// ��ȡ������ĳ��������࣬���Ҹ����౻ĳ�����������
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
