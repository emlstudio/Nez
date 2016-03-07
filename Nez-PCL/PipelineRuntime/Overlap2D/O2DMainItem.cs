﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Nez.Overlap2D
{
	public class O2DMainItem
	{
		public int uniqueId;
		public string itemIdentifier;
		public string itemName;
		public string customVars;
		public float x;
		public float y;
		public float scaleX;
		public float scaleY;
		public float originX;
		public float originY;
		public float rotation;
		public int zIndex;
		public String layerName;
		public Color tint;

		Dictionary<String,String> _customVarsDict;


		public Dictionary<String,String> getCustomVars()
		{
			if( _customVarsDict == null )
				parseCustomVars();

			return _customVarsDict;
		}


		public string getCustomVarString( string key )
		{
			if( _customVarsDict == null )
				parseCustomVars();

			string value = null;
			_customVarsDict.TryGetValue( key, out value );

			return value;
		}


		public float getCustomVarFloat( string key, float defaultValue = 0f )
		{
			if( _customVarsDict == null )
				parseCustomVars();

			string value = null;
			if( _customVarsDict.TryGetValue( key, out value ) )
				return float.Parse( value );

			return defaultValue;
		}


		public int getCustomVarInt( string key, int defaultValue = 0 )
		{
			if( _customVarsDict == null )
				parseCustomVars();

			string value = null;
			if( _customVarsDict.TryGetValue( key, out value ) )
				return int.Parse( value );

			return defaultValue;
		}


		public bool getCustomVarBool( string key, bool defaultValue = true )
		{
			if( _customVarsDict == null )
				parseCustomVars();

			string value = null;
			if( _customVarsDict.TryGetValue( key, out value ) )
				return bool.Parse( value );

			return defaultValue;
		}


		void parseCustomVars()
		{
			_customVarsDict = new Dictionary<string,string>();

			var vars = customVars.Split( ';' );
			for( int i = 0; i < vars.Length; i++ )
			{
				var tmp = vars[i].Split( ':' );
				if( tmp.Length > 1 )
					_customVarsDict.Add( tmp[0], tmp[1] );
			}
		}
	
	}
}

