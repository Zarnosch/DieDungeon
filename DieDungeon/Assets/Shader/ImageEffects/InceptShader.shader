﻿Shader "Image Effects/InceptShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Blending ("Color Blend", Float) = 0.0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _Blending;

			sampler _GlobalKeepColored;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 playerCol = tex2D(_GlobalKeepColored, i.uv);

				// YCbCr color space, only use grey
				fixed4 ycbcr = 0.299 * col.r + 0.587 * col.g + 0.144 * col.b;
				col = lerp(lerp(col, ycbcr, _Blending), playerCol, playerCol.a);
				return col;
			}
			ENDCG
		}
	}
}