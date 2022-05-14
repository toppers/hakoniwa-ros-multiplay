# Photon & Oculus による箱庭 VR 体験環境

本環境は，[Photonライブラリによる複数ロボットの連携シミュレータ](https://github.com/toppers/hakoniwa-ros-multiplay/tree/main/multiplay-photon)を利用したシミュレーション状況を，Oculus Quest2 で箱庭 VR 空間にダイブして臨場感のある体験を実現する環境です．

## 環境

本環境では，以下が必要となります．

ハード：Oculus Quest2
リンクケーブル：oculus quest 2用 ケーブル

また，Oculus と PC 間で通信できるように Oculus Link をインストーしておく必要があります．

現時点で，動作確認した環境構成は以下の通りです．

* Windows 11/WSL2 Ubuntu 20.04.3 LTS
* Unity 2021.3.0f1
* Unity Hub：3.1.2

## 準備

箱庭 VR 体験をする上で必要なセットアップ手順は以下の通りです．

* 箱庭モデルのインストール
* Unity の [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022?locale=ja-JP) をインストール
* Photon の App ID PUN を設定

### 箱庭モデルのインストール

箱庭モデルをインストールするために，以下のコマンドを実行しましょう．

```
$ bash oculus-photon/install.bash
```

* 補足
  * Unityモデルは git 上で管理するには大容量になるバイナリファイル等がありますので，そういったものは，ダウンロードして取得して展開する方針としております．

### Unity の [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022?locale=ja-JP) をインストール

まず，Unity Hub を起動しましょう．

![](https://camo.qiitausercontent.com/e87ff882b83864d3acbe557ad13cffc24de54d5e/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f61343462653762612d323434392d643630372d343737342d3130636537306661396637352e706e67)

次に，画面右上の「開く」をクリックして，先ほどクローンしたディレクトリをたどり，「hakoniwa-ros-multiplay/oculus-photon/avator」を選択します．

![](https://camo.qiitausercontent.com/1e04fc06e7b2efc5f17164c3853a2254efcfb5b2/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31393235386262622d663666652d353266312d353163352d6435663434643135386137372e706e67)

* 補足
  * 環境によりますが，自分の環境ですと，Unity 起動するのに数分かかりますので気長に待ちましょう．

Unity起動するとこうなります．

![](https://camo.qiitausercontent.com/2fd0c7415e4ddf7424f396188f0bbfb6fabc7106/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f35623735373439332d636432372d613633642d373164652d3438383234616338636130342e706e67)

画面下を見ると，赤字でエラー出てますが，Oculus Integration パッケージがインストールされてないためです．というわけで，いざインストールです．

こちらから，「Unityで開く」をクリックし，インストールします．

![](https://api.unity.com/v1/oauth2/authorize?client_id=asset_store_v2&locale=en_US&redirect_uri=https%3A%2F%2Fassetstore.unity.com%2Fauth%2Fcallback%3Fredirect_to%3D%252Fpackages%252Ftools%252Fintegration%252Foculus-integration-82022%253Flocale%253Dja-JP&response_type=code&state=344f1588-b6bc-4bdf-9da0-746bc55f37b3)

クリックすると，Unityのパッケージマネージャが起動し，Oculus Integration 画面が現れますので，ダウンロードして，インポートしましょう．

![](https://camo.qiitausercontent.com/aee14b3805b03d351596b424991152b90463c8e5/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f32313930633137632d343766352d393330352d333061342d3730666334343032323939332e706e67)

インポートボタンを押下すると，以下のダイアログが出てきますので，インポートします．

![](https://camo.qiitausercontent.com/da25baaf5ab8e9c22083545d7c3f4f0d92ce37c4/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f62323132393664632d623331372d353964372d666235362d3832373465373661636336312e706e67)

インポート中にいくつか確認ダイアログが出てきますが，一連の対応内容は以下の通りです．すべて終了すると，再起動して，画面下にあったエラーが消えます．


* Yes
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/939b6d78-63e9-a00d-b40f-8c3cf270e884.png)
* Use OpenXR
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/ebf9e361-72aa-8d27-7dda-fd89d61b138a.png)
* Ok
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/a380ec95-2a1d-7c87-53ba-153c9af7f606.png)
* Restart
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/8162d2fc-4442-3c0a-b09c-233c6dd38320.png)
* Upgrade
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/4a27a107-7cc1-3375-240b-82310c0fdb53.png)
* Restart
  * ![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/0c75d1cb-a4b5-9a5c-725a-dcb9c8092a14.png)

ここから，Unityのプロジェクト設定です．まずは，[Edit]->[Project Settings...]をクリックしましょう．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/4fd1bfaf-0a11-a3a8-ce90-8a818acfff0e.png)

画面左下の[XR Plugin Management]を選択すると，[Install XR Plugin Management]ボタンがありますので，クリックします．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/800f2c68-71f5-707c-b1b9-6336366b9c3d.png)

インストール終了後，中央にある[Oculus]にチェックを入れます．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/a251c14a-f6e6-b122-82df-fe76f01e2cb2.png)

最後に，Unityのプロジェクトビューの「Scenes」を選択して，「HakoniwaAvator」シーンをクリックしましょう．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/123fb687-01d6-90f4-cc14-430fcce593e7.png)

画面中央に，いつもの箱庭シミュレーション空間が現れます．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/bbe06f7a-ed47-2a68-1aa6-c71aadc05170.png)


### Photon の App ID PUN を設定
Unity の PhotonUnityNetworking設定で， App ID PUN を設定しましょう．

メニューの[Windows]->[Photon Unity Networking]->[PUN Wizard]をクリックしてください．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/4c2eb96f-edec-c516-8565-a6849835bbb6.png)

そうすると，以下のダイアログがポップアップされますので，Locate PhotonServerSettingsをクリックしましょう．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/315bcf08-f0a0-ab22-3985-bc091cb81edc.png)

インスペクタビューが開きますので，(T.B.D)となっているApp ID PUN に，登録したアプリケーションIDを入力してください．

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/244147/4e2db351-cbbb-9bbb-002a-f211861c414a.png)



### 動作例

箱庭 VR 空間にダイブするために，まずは， Photonライブラリによる複数ロボットの連携シミュレータを実行してください．

次に，Oculus Qeuest 2を装着して，PC 操作開始します．



https://user-images.githubusercontent.com/164193/168404160-0442d0f9-63e4-417f-afc0-da29afd1a8aa.mp4



VR空間に入ったら，先ほどセットアップしたUnityエディタ上で，シミュレーション開始します．



https://user-images.githubusercontent.com/164193/168404168-ff803c1f-d774-4af9-bb9d-8712e31ec784.mp4


## Contributing

本リポジトリで公開している「箱庭 ROS シミュレータ」について，ご意見や改善の提案などをぜひ [こちらのGitHub Discussions](https://github.com/toppers/hakoniwa/discussions/categories/idea-request) でお知らせください．改修提案の [Pull Requests](https://github.com/toppers/hakoniwa-ros2sim/pulls) も歓迎いたします．

## TODO

