/* -------------------------------------------------------------------------------------------------
Restricted. Copyright (C) Siemens Healthcare GmbH, 2015. All rights reserved.
-------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Spring.Context;
using Spring.Context.Support;

namespace StrategyPatternDemo.SpringHelper
{
    /// <see cref="ISpringContext"/>
    public class SpringContext : ISpringContext
    {
        private bool myIsDisposed;

        /// <see cref="ISpringContext.ApplicationContext"/>
        public IApplicationContext ApplicationContext { get; set; }

        /// <summary>
        /// Creates the ApplicationContext from a set of configuration files, but does NOT register the
        /// Context in the global spring <see cref="ContextRegistry"/>. This API is suitable for tests,
        /// which want to setup a temporary context in their TestFixtureSetup.
        /// </summary>
        /// <param name="springConfigurationFiles">Set of spring configuration files (xml)</param>
        public SpringContext( string[] springConfigurationFiles )
        {
            CheckExistenceOfConfigurationFiles( springConfigurationFiles );
            ApplicationContext = new FastLoadingXmlApplicationContext( string.Empty, springConfigurationFiles );
        }

        /// <summary>
        /// Creates the ApplicationContext from configuration files available in a directory
        /// </summary>
        /// <param name="springConfigBootstrapperPath">Path to bootstrapper spring configuration files (xml)</param>
        /// <param name="contextName">spring context will be registered with this name</param>
        public SpringContext( string springConfigBootstrapperPath, string contextName )
        {
            if( !Directory.Exists( springConfigBootstrapperPath ) )
            {
                throw new ArgumentException( String.Format( "Configuration file path {0} does not exist", springConfigBootstrapperPath ) );
            }

            var configFiles = Directory.EnumerateFiles( springConfigBootstrapperPath, "*.Bootstrapper.SpringConfig.xml" ).OrderBy( file => file ).ToArray();
            ApplicationContext = new FastLoadingXmlApplicationContext( contextName, configFiles );
        }

        /// <summary>
        /// Creates the ApplicationContext
        /// </summary>
        /// <param name="springConfigurationFiles">Set of spring configuration files (xml)</param>
        /// <param name="contextName">spring context will be registered with this name</param>
        public SpringContext( string[] springConfigurationFiles, string contextName )
        {
            // check if file exists
            CheckExistenceOfConfigurationFiles( springConfigurationFiles );

            // load configurations
            ApplicationContext = new FastLoadingXmlApplicationContext( contextName, springConfigurationFiles );

            // and register the context.
            ContextRegistry.RegisterContext( ApplicationContext );
        }

        /// <summary>
        /// Tells, whether the given <paramref name="contextName"/> was registered, already [true],
        /// or not [false].
        /// </summary>
        /// <remarks>
        /// Loading a spring-context with the same <paramref name="contextName"/> repeatedly will cause
        /// an exception in spring.
        /// </remarks>
        public static bool IsContextRegistered( string contextName )
        {
            return ContextRegistry.IsContextRegistered( contextName );
        }

        private void CheckExistenceOfConfigurationFiles( IEnumerable<string> springConfigurationFiles )
        {
            foreach( var springConfigurationFile in springConfigurationFiles )
            {
                // Check non-embedded xml files only, so filter our assemby resources.
                if( false == springConfigurationFile.ToUpper().Contains( "ASSEMBLY://" )
                    &&
                    false == springConfigurationFile.ToUpper().Contains( "CONFIG://" )
                    &&
                    false == File.Exists( springConfigurationFile ) )
                {
                    throw new ArgumentException( String.Format( "Configuration file {0} does not exist", springConfigurationFile ) );
                }
            }
        }

        /// <see cref="ISpringContext.GetObject{T}"/>
        public T GetObject<T>( string springObjectName ) where T : class
        {
            if( String.IsNullOrEmpty( springObjectName ) )
            {
                throw new ArgumentNullException( "springObjectName", "is null or empty." );
            }

            T springObject = ApplicationContext.GetObject( springObjectName ) as T;

            if( springObject == null )
            {
                throw new NullReferenceException( "Unable to retrieve instance from spring context." );
            }

            return springObject;
        }

        /// <see cref="ISpringContext.GetOptionalObject{T}"/>
        public T GetOptionalObject<T>( string springObjectName ) where T : class
        {
            if( ApplicationContext.ContainsLocalObject( springObjectName ) )
            {
                return GetObject<T>( springObjectName );
            }

            return null;
        }

        /// <see cref="ISpringContext.PreloadObject"/>
        public void PreloadObject( string springObjectName )
        {
            if( String.IsNullOrEmpty( springObjectName ) )
            {
                throw new ArgumentNullException( "springObjectName", "is null or empty." );
            }

            ApplicationContext.GetObject( springObjectName );
        }

        /// <see cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        private void Dispose( bool isDisposing )
        {
            if( myIsDisposed )
            {
                return;
            }

            if( isDisposing )
            {
                if( ApplicationContext != null )
                {
                    ApplicationContext.Dispose();
                }
            }

            myIsDisposed = true;
        }
    }
}