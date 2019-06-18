﻿using Grpc.Core;
using System;
using System.ComponentModel;

namespace ProtoBuf.Grpc.Internal
{
    [Obsolete(Reshape.WarningMessage, false)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class FullyNamedMethod<TRequest, TResponse> : Method<TRequest, TResponse>, IMethod
    {
        private readonly string _fullName;

        public FullyNamedMethod(
           string operationName,
           MethodType type,
           string serviceName,
           string? methodName = null,
           Marshaller<TRequest>? requestMarshaller = null,
           Marshaller<TResponse>? responseMarshaller = null)
           : base(type, serviceName, methodName ?? operationName,
#pragma warning disable CS0618
                 requestMarshaller ?? MarshallerCache<TRequest>.Instance,
                 responseMarshaller ?? MarshallerCache<TResponse>.Instance)
#pragma warning restore CS0618
        {
            _fullName = serviceName + "/" + operationName;
        }

        string IMethod.FullName => _fullName;
    }
}
