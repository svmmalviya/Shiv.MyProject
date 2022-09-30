using Shiv.MyProject.Debugging;

namespace Shiv.MyProject
{
    public class MyProjectConsts
    {
        public const string LocalizationSourceName = "MyProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c20ca3522726435aa6cd58a39630d66f";
    }
}
