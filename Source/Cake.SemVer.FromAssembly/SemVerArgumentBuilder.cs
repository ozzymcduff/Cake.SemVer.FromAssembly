using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.SemVer.FromAssembly
{
    public class SemVerArgumentBuilder<T>
        where T : SemVerSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly ProcessArgumentBuilder _builder;
        private readonly T _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemVerArgumentBuilder{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="setting">The settings</param>
        protected SemVerArgumentBuilder(ICakeEnvironment environment, T setting)
        {
            _environment = environment;
            _settings = setting;
            _builder = new ProcessArgumentBuilder();
        }

        public ProcessArgumentBuilder GetArguments()
        {
            AddArguments(_builder, _settings);
            return _builder;
        }

        void AddArguments(ProcessArgumentBuilder builder, T settings)
        {
            throw new NotImplementedException();
        }
   }
}
