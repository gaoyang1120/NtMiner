﻿using NTMiner.User;
using NTMiner.Ws;
using WebSocketSharp.Server;

namespace NTMiner.Core.Impl {
    public class MinerStudioSession : AbstractSession, IMinerStudioSession {
        /// <summary>
        /// 不会返回null
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userName"></param>
        /// <param name="wsSessionID"></param>
        /// <param name="wsSessionManager"></param>
        /// <returns></returns>
        public static MinerStudioSession Create(IUser user, WsUserName userName, string wsSessionID, WebSocketSessionManager wsSessionManager) {
            return new MinerStudioSession(user, userName, wsSessionID, wsSessionManager);
        }

        private MinerStudioSession(IUser user, WsUserName userName, string wsSessionID, WebSocketSessionManager wsSessionManager)
            : base(user, userName, wsSessionID, wsSessionManager) {
        }

        public bool IsValid(WsMessage message) {
            if (message == null || string.IsNullOrEmpty(message.Sign)) {
                return false;
            }
            var userData = WsRoot.ReadOnlyUserSet.GetUser(UserId.CreateLoginNameUserId(this.LoginName));
            if (userData == null) {
                return false;
            }
            return message.Sign == message.CalcSign(userData.Password);
        }
    }
}
