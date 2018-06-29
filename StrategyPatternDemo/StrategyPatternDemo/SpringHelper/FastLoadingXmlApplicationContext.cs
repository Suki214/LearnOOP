using System;
using System.Collections.Generic;

using Spring.Context.Support;
using Spring.Core.IO;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;

namespace StrategyPatternDemo.SpringHelper
{
    /// <summary>
    /// A XmlApplicationContext optimized for fast loading of spring configs
    /// </summary>
    internal class FastLoadingXmlApplicationContext : XmlApplicationContext
    {
        /// <summary>
        /// Constructs the context from given xml files with a given name
        /// </summary>
        /// <param name="name">name of the context used for context registration</param>
        /// <param name="springConfigurationFiles">list of spring config xml files</param>
        internal FastLoadingXmlApplicationContext( string name, params string[] springConfigurationFiles )
            : base( name, true, springConfigurationFiles ) { }

        /// <summary>
        /// Create a new reader instance for importing object definitions into the specified <paramref name="objectFactory"/>.
        /// </summary>
        /// <param name="objectFactory">the <see cref="DefaultListableObjectFactory"/> to be associated with the reader</param>
        /// <returns>a new <see cref="FastLoadingXmlObjectDefinitionReader"/> instance.</returns>
        protected override XmlObjectDefinitionReader CreateXmlObjectDefinitionReader( DefaultListableObjectFactory objectFactory )
        {
            return new FastLoadingXmlObjectDefinitionReader( objectFactory );
        }


        /// <summary>
        /// The Spring XmlObjectDefinitionReader optimized for loading Spring config files only once
        /// </summary>
        internal class FastLoadingXmlObjectDefinitionReader : XmlObjectDefinitionReader
        {
            private readonly List<string> myLoadedLocations;

            /// <summary>
            /// Constructs the Reader object with a given factory
            /// </summary>
            /// <param name="objectFactory">The object factory used to create objects defined in a spring config</param>
            internal FastLoadingXmlObjectDefinitionReader( DefaultListableObjectFactory objectFactory )
                : base( objectFactory )
            {
                myLoadedLocations = new List<string>();
            }

            /// <summary>
            /// Load object definitions from the supplied XML resource<paramref name="resource"/>.
            /// </summary>
            /// <param name="resource">The XML resource for the object definitions that are to be loaded.
            ///             </param>
            /// <returns>
            /// The number of object definitions that were loaded.
            /// </returns>
            /// <exception cref="T:Spring.Objects.ObjectsException">In the case of loading or parsing errors.
            ///             </exception>
            public override int LoadObjectDefinitions(IResource resource)
            {
                String location = resource.Uri.AbsolutePath;

                if( myLoadedLocations.Contains( location ) ) return 0;
                
                myLoadedLocations.Add( location );

                return base.LoadObjectDefinitions(resource);
            }

        }
    }
}