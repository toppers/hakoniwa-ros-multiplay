#!bin/bash


CURR=`pwd`

cd oculus-photon/avator/Assets

if [ -d Model ]
then
	:
	echo "Model is already installed."
else
	wget https://github.com/toppers/hakoniwa-ros-multiplay/releases/download/hakoniwa-ros-multiplay-v1.0.0/Model.tar.gz
	tar xzvf Model.tar.gz
	rm -f Model.tar.gz
fi

if [ -d Scripts ]
then
	:
	echo "Scripts is already installed."
	exit 1
else
	wget https://github.com/toppers/hakoniwa-ros-multiplay/releases/download/hakoniwa-ros-multiplay-v1.0.0/Scripts.tar.gz
	tar xzvf Scripts.tar.gz
	rm -f Scripts.tar.gz
fi

if [ -f Photon/PhotonUnityNetworking/Resources/HakoAvator.prefab ]
then
	:
	echo "Photon/PhotonUnityNetworking/Resources is already installed."
	exit 1
else
	wget https://github.com/toppers/hakoniwa-ros-multiplay/releases/download/hakoniwa-ros-multiplay-v1.0.0/Photon.tar.gz
	tar xzvf Photon.tar.gz
	rm -f Photon.tar.gz
fi

