# Photonライブラリによる複数ロボットの連携シミュレータ

本環境は，遠隔地に設置された複数台の PC 上で開発された Unity ロボットを，Unity & [Photon](https://www.photonengine.com/) ライブラリを利用して，複数ロボット制御シミュレーションを実現する環境です．

## 準備

本環境は，本リポジトリの `multiplay-photon/photon` ディレクトリに移動して，[箱庭 ROS シミュレータ](https://github.com/toppers/hakoniwa-ros2sim) と同じセットアップを実施することで利用できるようになります．


### Photonライブラリによる複数ロボットの連携制御シミュレータの利用方法

本環境で複数のロボットを動作させるには，以下の３点を理解する必要があります．

* Photonライブラリ向け箱庭ロボット・アセット
* Photonライブラリ向け箱庭ロボット・コンフィギュレータ
* Photonライブラリ向け箱庭ロボット・シミュレータ

上記は，[複数ロボットの連携制御シミュレータ](https://github.com/toppers/hakoniwa-ros-multiplay/tree/main/multiplay-local)と同じ構成・内容ですが，Photon ライブラリ向けに若干手順が異なります．

#### Photonライブラリ向け箱庭ロボット・アセット

Unityエディタのプロジェクトビューの「Assets/Photon/PhtonUnityNetworking/Resources」を開くと，TB3RoboModelというロボットが見えます．これが Photon 上で使える箱庭のロボットアセットになります．今は１種類しかないですが，今後，増やしていく予定です．

![](https://camo.qiitausercontent.com/391c82498490e3f537d5eb68d3fb455411e34b35/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f38376261353437652d383566662d356163302d616561642d3837353836383331383461372e706e67)

次に解説する「箱庭ロボット・コンフィギュレータ」上に，このロボットをドラッグ＆ドロップして，配置します．


#### Photonライブラリ向け箱庭ロボット・コンフィギュレータ

Unityエディタのプロジェクトビューの中に「Assets/Scenes/Configurator」があります．

![](https://camo.qiitausercontent.com/51acd75873c57a29eccfbad9e61bae807617c2f2/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f38363164376635302d656366302d353538372d396230352d6563383330663864383232652e706e67)

これをダブルクリックすると，ロボット配置用のシーンが現れます．
ロボットが存在しない状態で，１個追加してみましょう．

* 利用しなくなったロボットは，ヒエラルキービューの「Cofigurator/Hakoniwa/Robot」配下にいるロボットを選択して Deleteキーを押下すれば削除できます．


箱庭ロボット・アセット(プロジェクトビューの「Assets/Photon/PhtonUnityNetworking/Resources」)から，TB3RoboModelをドラッグして，ヒエラルキービューの「Configurator/Hakoniwa/Robot」配下にドロップしてください．

![](https://camo.qiitausercontent.com/f5ee033c8388fa0e28893972997f131a8a6d3f96/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31646235356437352d336130662d653566612d646336662d3737336165613563383131322e706e67)


ロボット名は，どのPC側のロボットかわかるように，今回は以下とします．

* PC1：tb3_pc1
* PC2：tb3_pc2

これで，コンフィグ完了です．これを箱庭に認識させるために，以下の２ステップを実施します．

* Unityエディタ上からロボット構成をjsonファイルに変換する
* ロボット構成jsonファイルを箱庭定義ファイルに変換する

ただし，Photon ライブラリ向けには，上記の１個目の作業で実施するjsonファイル生成では，メニューの[Windows]->[Hakoniwa]->[GeneratePhoton]をクリックしてください．

![](https://camo.qiitausercontent.com/0b0b6c950f849febbc8f453b88740a071691ee48/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f30333534656263382d656663352d323533382d356133622d6431623637396262633030352e706e67)


成功すると，Consoleビューに，jsonファイルを生成したログが見えます．

![](https://camo.qiitausercontent.com/7d62ae26137160e43af3de5c79c31409540ec34b/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31626561303064362d316263362d653230342d613466362d3633393861656137363430382e706e67)

実は，このjsonファイル，hakoniwa-ros2sim/settings/tb3/RosTopics.jsonとして生成されています．jsonファイルですので，テキストエディタで開くことができます．ロボットが出版・購読するROSトピック一覧が列挙されていますので，興味のある方はぜひご覧ください．

あとは，このjsonファイルをベースに，dockerコンテナ上で，箱庭のコンフィグファイルを生成して終了です．

```
# pwd
/root/workspace/hakoniwa-ros2sim/ros2/workspace
# bash hako-install.bash
###Phase3: Creating core_config
####Creating core_config
####Creating ros_topic_method
####Creating inside_assets
####Creating pdu_readers
####Creating pdu_writers
####Creating reader_channels
####Creating writer_channels
####Creating pdu_channel_connectors
####Creating unity_ros_params
####Creating pdu_config
####Creating param_world
####Creating tb3_parts
###Phase3: Succless
Model is already installed.
Plugin is already installed.
Resources is already installed.
```


#### 箱庭ロボット・シミュレータ

Photonライブラリを利用したシミュレーション実行は，Toppers_Courseシーンを使って，[複数ロボットの連携制御シミュレータ](https://github.com/toppers/hakoniwa-ros-multiplay/tree/main/multiplay-local)と同じ手順で実施できます．

ただし，シミュレーション実施する前に，以下を実施する必要があります．

* PhotonUnityNetworking設定でのアプリケーションID登録

##### PhotonUnityNetworking設定でのアプリケーションID登録

メニューの[Windows]->[Photon Unity Networking]->[PUN Wizard]をクリックしてください．

![](https://camo.qiitausercontent.com/f565de71ae0f44d8abcf6ebe74d370962cb39e8a/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f34623235393034382d323866612d326433352d373332352d3734306466353535363762622e706e67)

以下のダイアログがポップアップされますので，`Locate PhotonServerSettings` をクリックしましょう．

![](https://camo.qiitausercontent.com/25139f2147cce805c71f92353e4feef176c35bfe/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f65353436613665302d393533622d373332392d336230342d3833313461363632643636652e706e67)

インスペクタビューが開きますので，`(T.B.D)` となっているApp ID PUN に，登録したアプリケーションIDを入力してください．

![](https://camo.qiitausercontent.com/44a18be628534f2800438505dc97156abf845810/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f33623432323936312d623932332d366131662d623830652d3030646462336362643233382e706e67)


### 動作例

以下に，シミュレーション実行風景をお見せしますので，ぜひ試してみてください！
シミュレーション開始すると，途中から，遠隔地でシミュレーション開始したロボットが登場して動き出します．

https://user-images.githubusercontent.com/164193/168399974-291dea61-69dc-4490-9115-e1699b2a4b50.mp4



## Contributing

本リポジトリで公開している「箱庭 ROS シミュレータ」について，ご意見や改善の提案などをぜひ [こちらのGitHub Discussions](https://github.com/toppers/hakoniwa/discussions/categories/idea-request) でお知らせください．改修提案の [Pull Requests](https://github.com/toppers/hakoniwa-ros2sim/pulls) も歓迎いたします．

## TODO
