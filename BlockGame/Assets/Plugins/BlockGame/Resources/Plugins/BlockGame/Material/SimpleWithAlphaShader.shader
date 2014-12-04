Shader "Custom/SimpleWithAlphaShader" {
	Properties 
	{
		_MyColor ("My First Color", Color) = (1, 1, 1, 1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		float4 _MyColor;
		
		struct Input
		{
			float4 _MyColor;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			float4 c = _MyColor;
			o.Albedo = c.rgb;
			o.Emission = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
