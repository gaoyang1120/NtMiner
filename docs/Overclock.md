# 关于A卡超频

开源矿工很早就支持了N卡超频，不依赖小飞机且支持阉割版的矿卡系列，因为使用的是流出自NVIDA内部的超频工具，所以N卡超频是可信可靠的。但一直没有支持A卡超频，主要是因为网上找不到满意的适合嵌入进开源矿工的A卡超频工具，伟人说：自己动手丰衣足食，中国人从来都不比老外弱，所以还是自己动手吧。

在实现过程中发现，超频一直是AMD的强项，是AMD的一件历史悠久的事情，所以超频接口也是稳定可靠且版本兼容的，这一点应该给AMD个赞。
[这是AMD的文档](https://github.com/GPUOpen-LibrariesAndSDKs/display-library)
[用到的相关接口](https://github.com/ntminer/ntminer/blob/master/src/NTMiner.Core/Core/Gpus/Impl/Amd/AdlNativeMethods.cs)

已实现并上线，自版本号NTMiner 2.2.0.0往后都支持A卡超频。

# 完备实现超频
众所周知，为了提高收益，显卡挖矿通常会超频工作。在开源矿工未上线的石器时代，人们通常使用笨重的微星小飞机进行超频。

上一次开源矿工自主实现了A卡的超频功能促进了行业以及竞品的进步，上次N卡的超频是基于NVIDIA内部流出的工具实现的而不是自主的，现在开源矿工全网首次自主实现了全系显卡功能完备的超频功能，这里功能完备的意思是指功能没有缺憾以及超频结果的可见。

这个工作已经上线一段时间了，因为开源矿工的源码是完全开源的，根据传统现在需要指出如何实现这些功能。

[相关代码的位置在](https://github.com/ntminer/ntminer/tree/master/src/NTMinerGpus/Gpus)

代码已经相当清晰，希望对竞品有用。值得说明的是开源矿工的超频实现对全系显卡有效，包括NVIDIA p系列的专业矿卡，10系以及20系卡，以及全系A卡。