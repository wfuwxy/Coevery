﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coevery.Core.Models;
using Newtonsoft.Json.Linq;
using Orchard;
using Orchard.Environment.Extensions.Models;

namespace Coevery.Core.ClientRoute {
    public interface IClientRouteProvider : IDependency {
        Feature Feature { get; }
        bool IsFrontEnd { get; }
        void Discover(ClientRouteTableBuilder builder);
    }

    public abstract class ClientRouteProviderBase : IClientRouteProvider {
        public Feature Feature { get; set; }
        public bool IsFrontEnd { get; set; }

        public abstract void Discover(ClientRouteTableBuilder builder);

        protected string ToClientUrl(string script) {
            var basePath = VirtualPathUtility.AppendTrailingSlash(Feature.Descriptor.Extension.Location + "/" + Feature.Descriptor.Extension.Id);
            if (script == null) return null;
            var virtualPath = VirtualPathUtility.Combine(VirtualPathUtility.Combine(basePath, "Scripts/"), script + ".js");
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }
    }
}