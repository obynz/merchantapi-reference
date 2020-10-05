﻿// Copyright (c) 2020 Bitcoin Association

using System;
using System.Collections.Generic;
using System.Text;
using MerchantAPI.APIGateway.Test.Functional.CallBackWebServer;
using Microsoft.AspNetCore.Http;

namespace MerchantAPI.APIGateway.Test.Stress
{

  /// <summary>
  /// Implementation if ICallBackReceived that just counts call backs
  /// </summary>
  public class CallBackReceived : ICallBackReceived
  {
    readonly Stats stats;
    public CallBackReceived(Stats stats)
    {
      this.stats = stats;
    }
    public void CallbackReceived(string path, byte[] data)
    {
      stats.IncrementCallbackReceived();
    }
  }
}
