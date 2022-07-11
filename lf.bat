git init
git lfs install

git lfs track UnityPlayer.dll
git lfs track InjeGuideMap.apk
git lfs track sharedassets2.assets
git lfs track sharedassets2.assets.resS

git add *
git commit -m "commit by lfs"
git checkout -b main
git remote add origin https://github.com/JengHC/InJe_Guide_Map.git
git push origin main
