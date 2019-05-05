﻿using NTMiner.Core;
using NTMiner.Vms;
using System;
using System.Collections.Generic;

namespace NTMiner {
    public partial class AppContext {
        public class PoolProfileViewModels : ViewModelBase {
            public static readonly PoolProfileViewModels Instance = new PoolProfileViewModels();
            private readonly Dictionary<Guid, PoolProfileViewModel> _dicById = new Dictionary<Guid, PoolProfileViewModel>();

            private PoolProfileViewModels() {
                On<PoolProfilePropertyChangedEvent>("矿池设置变更后刷新VM内存", LogEnum.DevConsole,
                    action: message => {
                        if (_dicById.TryGetValue(message.PoolId, out PoolProfileViewModel vm)) {
                            vm.OnPropertyChanged(message.PropertyName);
                        }
                    });
                On<LocalContextReInitedEvent>("MinerProfile刷新后刷新VM内存", LogEnum.DevConsole,
                    action: message => {
                        _dicById.Clear();
                    });
            }

            private readonly object _locker = new object();
            public PoolProfileViewModel GetOrCreatePoolProfile(Guid poolId) {
                PoolProfileViewModel poolProfile;
                if (!_dicById.TryGetValue(poolId, out poolProfile)) {
                    lock (_locker) {
                        if (!_dicById.TryGetValue(poolId, out poolProfile)) {
                            poolProfile = new PoolProfileViewModel(NTMinerRoot.Instance.MinerProfile.GetPoolProfile(poolId));
                            _dicById.Add(poolId, poolProfile);
                        }
                    }
                }
                return poolProfile;
            }
        }
    }
}
