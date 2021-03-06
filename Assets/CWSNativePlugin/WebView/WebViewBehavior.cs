using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_IPHONE
using Kogarasi.WebView;

public class WebViewBehavior : MonoBehaviour
{

	IWebView			webView;
	IWebViewCallback	callback;

#region Method

	public void Awake()
	{
		webView = new WebViewIOS();

		webView.Init( name );

		callback = null;
	}

	public void OnDestroy()
	{
		webView.Term();
	}

	public void SetMargins( int left, int top, int right, int bottom )
	{
		webView.SetMargins( left, top, right, bottom );
	}
	public void SetVisibility( bool state )
	{
		webView.SetVisibility( state );
	}

	public void LoadURL( string url )
	{
		webView.LoadURL( url );
	}

	public void EvaluateJS( string js )
	{
		webView.EvaluateJS( js );
	}

	/*
	public void CallFromJS( string message )
	{
		Debug.Log( "CallFromJS : " + message );
	}
	*/

	public void SimpleFunction(string gameObjectName, string funcName, string arg)
	{
		webView.SimpleFunction(gameObjectName, funcName, arg);
	}

	public void setCallback( IWebViewCallback _callback )
	{
		callback = _callback;
	}

	public void onLoadStart( string url )
	{
		if( callback != null )
		{
			callback.onLoadStart( url );
		}
	}

	public void onLoadFinish( string url )
	{
		if( callback != null )
		{
			callback.onLoadFinish( url );
		}
	}

	public void onLoadFail( string url )
	{
		if( callback != null )
		{
			callback.onLoadFail( url );
		}
	}

#endregion

}
#endif
