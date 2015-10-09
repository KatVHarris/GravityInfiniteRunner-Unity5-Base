Shader "Effects/Matrix/GlowAdditiveSimple" {
	Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_CoreColor ("Core Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}
	_TintStrength ("Tint Color Strength", Range(0, 5)) = 1
	_CoreStrength ("Core Color Strength", Range(0, 8)) = 1
	_CutOutLightCore ("CutOut Light Core", Range(0, 1)) = 0.5
	
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha One
	AlphaTest Greater .01
	ColorMask RGB
	Cull Off 
	Lighting Off 
	ZWrite Off 
	Fog { Color (0,0,0,0) }
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
		
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			fixed4 _CoreColor;
			float _CutOutLightCore;
			float _TintStrength;
			float _CoreStrength;
			float4x4 _DecalMatr;  
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				float3 pTex : TEXCOORD1;
				
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				//o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				float4 trasformed = mul(_DecalMatr,  v.vertex);
                o.pTex = trasformed.xyz+float3(0.5, 0.5, 0);
				o.texcoord = TRANSFORM_TEX(o.pTex,_MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : COLOR
			{
				fixed4 tex = tex2D(_MainTex, i.texcoord);
				if(i.pTex.y<0 || i.pTex.y>1 || i.pTex.x < 0 || i.pTex.x > 1) {
				  tex.a=0; 
				}
				fixed4 col = (_TintColor * tex.g * _TintStrength + tex.r * _CoreColor * _CoreStrength  - _CutOutLightCore)* tex.a; 
				return clamp(col, 0, 255);
			}
			ENDCG 
		}
	}	
}
}
