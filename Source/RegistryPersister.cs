using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    internal class RegistryPersister {
        private static Dictionary<OptionName, RegistryEntry> registryOptions = new Dictionary<OptionName, RegistryEntry>  {
            {
                OptionName.LoadAtSystemStartup,
                new RegistryEntry {
                    Hive = Registry.CurrentUser,
                    Key = @"Software\Microsoft\Windows\CurrentVersion\Run",
                    Name = Application.ProductName,
                    Value = $"\"{Application.ExecutablePath}\"",
                    ExistsCallback = (entry, key) => key.GetValue(entry.Name)?.ToString().StartsWith(entry.Value),
                }
            },
        };

        public RegistryPersister(RegistryOptions options) {
            Options = options;
        }

        public RegistryOptions Options { get; set; }

        public void Save() {
            foreach (var registryOption in registryOptions) {
                var option = registryOption.Key;
                var entry = registryOption.Value;

                using (var key = entry.Hive.OpenSubKey(entry.Key, true)) {
                    if ((bool)typeof(RegistryOptions).GetProperty(option.ToString()).GetValue(Options)) {
                        key.SetValue(entry.Name, entry.Value);
                    }
                    else {
                        key.DeleteValue(entry.Name, false);
                    }
                }
            }
        }

        public void Load() {
            foreach (var registryOption in registryOptions) {
                typeof(RegistryOptions).GetProperty(registryOption.Key.ToString()).SetValue(Options, registryOption.Value.Exists());
            }
        }

        private enum OptionName {
            LoadAtSystemStartup,
        }

        private struct RegistryEntry {
            public delegate bool? EntryExistsDelegate(RegistryEntry entry, RegistryKey key);

            public RegistryKey Hive { get; set; }

            public string Key { get; set; }

            public string Name { get; set; }

            public string Value { get; set; }

            public EntryExistsDelegate ExistsCallback { get; set; }

            public bool Exists() {
                using (var key = Hive.OpenSubKey(Key)) {
                    return ExistsCallback?.Invoke(this, key) == true;
                }
            }
        }
    }
}
