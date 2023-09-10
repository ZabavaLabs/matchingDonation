//------------------------------------------------------------------------------
// This code was generated by a tool.
//
//   Tool : MetaMask Unity SDK ABI Code Generator
//   Input filename:  ERC20.sol
//   Output filename: ERC20Backing.cs
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// <auto-generated />
//------------------------------------------------------------------------------

#if UNITY_EDITOR || !ENABLE_MONO
using System;
using System.Numerics;
using System.Threading.Tasks;
using evm.net;
using evm.net.Models;

namespace MetaMask.Contracts
{
	public class ERC20Backing : Contract, ERC20
	{
		public string Address
		{
			get => base.Address;
		}
		public ERC20Backing(IProvider provider, EvmAddress address, Type interfaceType) : base(provider, address, interfaceType)
		{
		}
		public Task<ERC20> DeployNew(String name_, String symbol_)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<ERC20>) InvokeMethod(method, new object[] { name_, symbol_ });
		}
		
		[EvmMethodInfo(Name = "allowance", View = true)]
		public Task<BigInteger> Allowance(EvmAddress owner, EvmAddress spender)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<BigInteger>) InvokeMethod(method, new object[] { owner, spender });
		}
		
		[EvmMethodInfo(Name = "approve", View = false)]
		public Task<Transaction> Approve(EvmAddress spender, BigInteger amount)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<Transaction>) InvokeMethod(method, new object[] { spender, amount });
		}
		
		[EvmMethodInfo(Name = "balanceOf", View = true)]
		public Task<BigInteger> BalanceOf(EvmAddress account)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<BigInteger>) InvokeMethod(method, new object[] { account });
		}
		
		[EvmMethodInfo(Name = "decimals", View = true)]
		[return: EvmParameterInfo(Type = "uint8")]
		public Task<BigInteger> Decimals()
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<BigInteger>) InvokeMethod(method, new object[] {  });
		}
		
		[EvmMethodInfo(Name = "decreaseAllowance", View = false)]
		public Task<Transaction> DecreaseAllowance(EvmAddress spender, BigInteger subtractedValue)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<Transaction>) InvokeMethod(method, new object[] { spender, subtractedValue });
		}
		
		[EvmMethodInfo(Name = "increaseAllowance", View = false)]
		public Task<Transaction> IncreaseAllowance(EvmAddress spender, BigInteger addedValue)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<Transaction>) InvokeMethod(method, new object[] { spender, addedValue });
		}
		
		[EvmMethodInfo(Name = "name", View = true)]
		public Task<String> Name()
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<String>) InvokeMethod(method, new object[] {  });
		}
		
		[EvmMethodInfo(Name = "symbol", View = true)]
		public Task<String> Symbol()
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<String>) InvokeMethod(method, new object[] {  });
		}
		
		[EvmMethodInfo(Name = "totalSupply", View = true)]
		public Task<BigInteger> TotalSupply()
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<BigInteger>) InvokeMethod(method, new object[] {  });
		}
		
		[EvmMethodInfo(Name = "transfer", View = false)]
		public Task<Transaction> Transfer(EvmAddress to, BigInteger amount)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<Transaction>) InvokeMethod(method, new object[] { to, amount });
		}
		
		[EvmMethodInfo(Name = "transferFrom", View = false)]
		public Task<Transaction> TransferFrom(EvmAddress from, EvmAddress to, BigInteger amount)
		{
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			return (Task<Transaction>) InvokeMethod(method, new object[] { from, to, amount });
		}
		
	}
}
#endif
