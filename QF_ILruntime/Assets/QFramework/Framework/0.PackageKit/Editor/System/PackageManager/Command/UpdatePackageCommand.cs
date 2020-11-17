﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace QFramework.PackageKit.Command
{
    public class UpdatePackageCommand : IPackageManagerCommand
    {
        public UpdatePackageCommand(PackageRepository packageRepository)
        {
            mPackageRepository = packageRepository;
        }
        
        private readonly PackageRepository mPackageRepository;
        
        public void Execute()
        {
            var path = Application.dataPath.Replace("Assets", mPackageRepository.installPath);

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            RenderEndCommandExecuter.PushCommand(() =>
            {
                AssetDatabase.Refresh();
                        
                PackageApplication.Container.Resolve<PackageKitWindow>().Close();

                InstallPackage.Do(mPackageRepository);
            });
        }
    }
}