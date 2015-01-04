Shader "Custom/GhostShader"
{
    Properties {
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (0, 0.1)) = .005
		_MainColor ("Main Color", Color) = (0,0,0,1)
        _MainTex ("Texture", 2D) = "white" { }
        _WaveTime ("WaveTime", float) = 200
    }
 
    SubShader {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            // Pass drawing outline
            Cull Front
       
            Blend SrcAlpha OneMinusSrcAlpha
           
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f members uv_MainTex)
#pragma exclude_renderers d3d11 xbox360
			#include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
           
            uniform float _Outline;
            uniform float4 _OutlineColor;
            uniform float4 _MainTex_ST;
            uniform sampler2D _MainTex;
 
            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
                float2 uv_MainTex;
            };
           
            v2f vert(appdata_base v)
            {
                v2f o;
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float2 offset = TransformViewToProjection(norm.xy);
                o.pos.xy += offset  * _Outline;
                o.color = _OutlineColor;
                return o;
            }
           
            half4 frag(v2f i) :COLOR
            {
            	half4 c = tex2D (_MainTex, i.uv_MainTex);
            	return i.color;
            }
                   
            ENDCG
        }
       
        Pass
        {  
            // pass drawing object
            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
           
            uniform float4 _MainTex_ST;
            uniform sampler2D _MainTex;
			uniform float4 _MainColor;
			uniform float _WaveTime;

            struct v2f {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };
           
            v2f vert(appdata_base v) {
                v2f o;
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.texcoord;
                return o;
            }
           
            half4 frag(v2f i) :COLOR
            {
                half4 c = tex2D (_MainTex, _MainTex_ST.xy * i.uv.xy + _MainTex_ST.zw);
                
                float wave = sin(_Time * _WaveTime / 3) * sin(_Time * _WaveTime) * 0.1f + 0.4f;
                
                c.r *= ( _MainColor.r * 0.5f + wave );
                c.g *= ( _MainColor.g * 0.5f + wave );
                c.b *= ( _MainColor.b * 0.5f + wave );
                
                return c;
            }
                   
            ENDCG
        }
    }
   
    Fallback Off
}
