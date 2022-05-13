# 複数ロボットの連携制御シミュレータ

本環境は，Unity 上で複数のロボットを配置して，ROS2 でロボット制御シミュレーションを実現する環境です．

## 準備

本環境は，[箱庭 ROS シミュレータ](https://github.com/toppers/hakoniwa-ros2sim) をセットアップすることで利用できるようになります．

### 複数ロボットの連携制御シミュレータの利用方法

本環境で複数のロボットを動作させるには，以下の３点を理解する必要があります．

* 箱庭ロボット・アセット
* 箱庭ロボット・コンフィギュレータ
* 箱庭ロボット・シミュレータ

#### 箱庭ロボット・アセット

Unityエディタのプロジェクトビューの「Assets/Resources/Hakoniwa/Robots」を開くと，TB3RoboModelというロボットが見えます．これが箱庭のロボットアセットになります．今は１種類しかないですが，今後，増やしていく予定です．

![](https://camo.qiitausercontent.com/97fbec7b621a6498f1e1091896588e8a2841256e/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f39323937326363662d396635352d333065622d653433372d3032633732333131303864662e706e67)

複数のロボットを配置する場合は，次に解説する「箱庭ロボット・コンフィギュレータ」上に，このロボットをドラッグ＆ドロップして，配置します．

#### 箱庭ロボット・コンフィギュレータ

Unityエディタのプロジェクトビューの中に「Assets/Scenes/Configurator」があります．

![](https://camo.qiitausercontent.com/51acd75873c57a29eccfbad9e61bae807617c2f2/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f38363164376635302d656366302d353538372d396230352d6563383330663864383232652e706e67)

これをダブルクリックすると，ロボット配置用のシーンが現れます．現状は１個のロボットしか見えませんが，ここにもう１個追加してみましょう．

![](https://camo.qiitausercontent.com/8b820d5856f2bf5b733f98ed914dce875d359786/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f32323964666331612d666639382d663765642d316533302d3332653063623530396362382e706e67)

やり方は単純で，箱庭ロボット・アセット(プロジェクトビューの「Assets/Resources/Hakoniwa/Robots」)から，TB3RoboModelをドラッグして，ヒエラルキービューの「Configurator/Hakoniwa/Robot」配下にドロップしてください．

![](https://camo.qiitausercontent.com/79c4bb767ac95ee703cd3f1bc41a95c9a3a20e02/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f39313765663163652d626434372d643030312d623333632d3461343634633731356364302e706e67)

うまく行くと，TB3RoboModel(1)が現れます．シーンビューでは１個しか見えませんが，重なっているからです．ロボットをマウスで移動させると，２個いるのがわかります．

![](https://camo.qiitausercontent.com/5078e3155121d07024bfbac98c9567f24382d560/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31663735626439352d306535372d383733382d316636622d3632356334376264333161642e706e67)

ところで，ロボットの名前が気になりませんか？ロボットをクリックして，インスペクタービュー上でロボットの名前をそれぞれ「tb3_1」，「tb3_2」として変更してください．

これで，コンフィグ完了です．これを箱庭に認識させるために，以下の２ステップを実施します．

* Unityエディタ上からロボット構成をjsonファイルに変換する
* ロボット構成jsonファイルを箱庭定義ファイルに変換する

まずは，メニューの[Windows]->[Hakoniwa]->[Generate]をクリックしてください．

![](https://camo.qiitausercontent.com/e2ff8a9a7acc7ce0f87f6e7c6c9bca55299f75e1/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31336530356133632d623332302d656635622d373564632d6133643539356238343662322e706e67)

成功すると，Consoleビューに，jsonファイルを生成したログが見えます．

![](https://camo.qiitausercontent.com/7d62ae26137160e43af3de5c79c31409540ec34b/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f31626561303064362d316263362d653230342d613466362d3633393861656137363430382e706e67)

実は，このjsonファイル，hakoniwa-ros2sim/settings/tb3/RosTopics.jsonとして生成されています．jsonファイルですので，テキストエディタで開くことができます．ロボットが出版・購読するROSトピック一覧が列挙されていますので，興味のある方はぜひご覧ください．

あとは，このjsonファイルをベースに，dockerコンテナ上で，箱庭のコンフィグファイルを生成して終了です．

```
# pwd
/root/workspace/hakoniwa-ros-samples/ros2/workspace
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

ロボット配置は，箱庭ロボット・コンフィギュレータでやっていましたが，シミュレーションは箱庭ロボット・シミュレータで行います．プロジェクトビューの「Assets/Scenes/Toppers_Course」をダブルクリックしてください．

![](https://camo.qiitausercontent.com/636ef0853f7a5822d586fcf6f4e16012ea9af720/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f34356131323064322d383862332d663862622d346438322d3638336132376437356666382e706e67)

成功するとこうなります．

![](https://camo.qiitausercontent.com/9dd31f331392e1c007cf4289e1cb5f39ba089031/68747470733a2f2f71696974612d696d6167652d73746f72652e73332e61702d6e6f727468656173742d312e616d617a6f6e6177732e636f6d2f302f3234343134372f38613065306434612d343133622d626339612d376531362d3763643633303166323330342e706e67)

あれ？先ほど配置したロボット見えませんよね．大丈夫です．シミュレーション実行時に箱庭が自動的にインスタンス化してくれます．

シミュレーション実行方法は，ロボットが１個の場合と同じですが，今回はTB3がもう１個増えましたので，attach.bash でもう１個 docker コンテナを立ち上げましょう．

### 動作例

以下に，シミュレーション実行風景をお見せしますので，ぜひ試してみてください！



https://user-images.githubusercontent.com/164193/168401051-a3ee178f-e1be-434e-8dd0-125473d84071.mp4



## Contributing

本リポジトリで公開している「箱庭 ROS シミュレータ」について，ご意見や改善の提案などをぜひ [こちらのGitHub Discussions](https://github.com/toppers/hakoniwa/discussions/categories/idea-request) でお知らせください．改修提案の [Pull Requests](https://github.com/toppers/hakoniwa-ros2sim/pulls) も歓迎いたします．

## TODO
