packProject()
{
echo "****************************************"
echo "Packing $1"
echo "****************************************"
echo "                                        "
cd $1
rm -f $1*.nupkg
nuget pack -IncludeReferencedProjects
cp $1*.nupkg "K:\Software Development\Tekhub Nuget Packages"
cd ..
echo "                                        "
}


packProject Tekhub.Identity.Social.Facebook
packProject Tekhub.Identity.Social.Facebook.Common
packProject Tekhub.Social.Facebook.Common
packProject Tekhub.Social.Facebook.Factory
packProject Tekhub.Social.Facebook.Repository
packProject Tekhub.Social.Facebook.Repository.Common
