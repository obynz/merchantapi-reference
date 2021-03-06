﻿// Copyright (c) 2020 Bitcoin Association

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MerchantAPI.Common.BitcoinRpc.Responses;

namespace MerchantAPI.APIGateway.Domain.Models
{
  /// <summary>
  /// Handles RPC calls to multiple nodes.
  /// </summary>
  public interface IRpcMultiClient
  {

    Task<RpcSendTransactions> SendRawTransactionsAsync(
      (byte[] transaction, bool allowhighfees, bool dontCheckFees)[] transactions);

    Task<byte[]> GetRawTransactionAsBytesAsync(string txId);
    Task<RpcGetBlockchainInfo> GetWorstBlockchainInfoAsync();
    Task<RpcGetBlockchainInfo> GetBestBlockchainInfoAsync();
    Task<(RpcGetRawTransaction firstOkResult, bool allOkTheSame, Exception firstError)> GetRawTransactionAsync(string id);
    Task<RpcGetMerkleProof> GetMerkleProofAsync(string txId, string blockHash);
    Task<byte[]> GetBlockAsBytesAsync(string blockHash);
    Task<RpcGetBlockHeader> GetBlockHeaderAsync(string blockHash);
    Task<RpcGetNetworkInfo> GetAnyNetworkInfoAsync();
    Task<RpcGetTxOuts> GetTxOutsAsync(IEnumerable<(string txId, long N)> outpoints, string[] fieldList);
  }
}
