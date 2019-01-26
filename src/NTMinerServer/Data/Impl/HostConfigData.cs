﻿using System;

namespace NTMiner.Data.Impl {
    public class HostConfigData : IHostConfig {
        public Guid Id { get; set; }
        public string OssAccessKeyId { get; set; }
        public string OssAccessKeySecret { get; set; }
        public string OssEndpoint { get; set; }
        public ulong ServerJsonVersion { get; set; }
    }
}
