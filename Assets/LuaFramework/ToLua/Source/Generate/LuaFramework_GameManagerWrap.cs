﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaFramework_GameManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaFramework.GameManager), typeof(Manager));
		L.RegFunction("InitGui", InitGui);
		L.RegFunction("CheckExtractResource", CheckExtractResource);
		L.RegFunction("OnResourceInited", OnResourceInited);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitGui(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.GameManager obj = (LuaFramework.GameManager)ToLua.CheckObject(L, 1, typeof(LuaFramework.GameManager));
			obj.InitGui();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckExtractResource(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.GameManager obj = (LuaFramework.GameManager)ToLua.CheckObject(L, 1, typeof(LuaFramework.GameManager));
			obj.CheckExtractResource();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnResourceInited(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.GameManager obj = (LuaFramework.GameManager)ToLua.CheckObject(L, 1, typeof(LuaFramework.GameManager));
			obj.OnResourceInited();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}
}

