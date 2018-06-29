/* -------------------------------------------------------------------------------------------------
Restricted. Copyright (C) Siemens Healthcare GmbH, 2015. All rights reserved.
-------------------------------------------------------------------------------------------------- */

using System;

using Spring.Context;

namespace StrategyPatternDemo.SpringHelper
{
    /// <see cref="IDisposable"/>
    /// <summary>
    /// This interface provides a more convenient API for underlying spring context
    /// </summary>
    public interface ISpringContext : IDisposable
    {
        /// <summary>
        /// The spring ApplicationContext created from the provided config files.
        /// </summary>
        IApplicationContext ApplicationContext { get; set; }

        /// <summary>
        /// This method can be used to access an object that is managed by spring. The method takes care about casting and
        /// validation that the access was successful.
        /// </summary>
        /// <typeparam name="T">The type of the object to be accessed.</typeparam>
        /// <param name="springObjectName">The spring id of the object.</param>
        /// <returns>The spring object.</returns>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the springObjectName parameter is null or empty.
        /// </exception>
        /// <exception cref="Exception">
        /// Throws an exception if the object could not be retrieved.
        /// </exception>
        T GetObject<T>( string springObjectName ) where T : class;

        /// <summary>
        /// This method can be used to access an object that is managed by spring. The method takes care about casting and
        /// validation that the access was successful.
        /// </summary>
        /// <typeparam name="T">The type of the object to be accessed.</typeparam>
        /// <param name="springObjectName">The spring id of the object.</param>
        /// <returns>The spring object.</returns>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the springObjectName parameter is null or empty.
        /// </exception>
        T GetOptionalObject<T>( string springObjectName ) where T : class;

        /// <summary>
        /// (Pre)Load the object an all its dependencies, but did not return it for usages
        /// </summary>
        /// <param name="springObjectName">The spring id of the object.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the springObjectName parameter is null or empty.
        /// </exception>
        void PreloadObject( string springObjectName );
    }
}