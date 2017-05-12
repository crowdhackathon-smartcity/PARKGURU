using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Runtime.Caching;
using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;

namespace SmartOnStreetParking.Web.Utils
{
    public class ApplicationCache
    {
        private static ObjectCache _AppCache = MemoryCache.Default;

        private static string _MemberKey = "Members_";

        public static Member GetMember(long MemberId)
        {
            if (MemberId <= 0) { return null; }
            Member MemberInfo = _AppCache[_MemberKey + MemberId.ToString()] as Member;
            if (MemberInfo == null)
            {
                MemberInfo = LoadMember(MemberId);
                if (MemberInfo != null)
                {
                    CacheItemPolicy Policy = CreatePolicy(new TimeSpan(0, 0, 1, 0, 0));
                    _AppCache.Set(_MemberKey + MemberId.ToString(), MemberInfo, Policy);
                }
            }
            return MemberInfo;
        }




        private static Member LoadMember(long MemberId)
        {
            MemberRepository Rep = new MemberRepository();
            return Rep.GetById(MemberId);
        }

        private static CacheItemPolicy CreatePolicy(TimeSpan Expiration)
        {
            CacheItemPolicy Policy = new CacheItemPolicy();

            Policy.SlidingExpiration = Expiration;

            return Policy;
        }
    }
}