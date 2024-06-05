Shader "NINJA - PBR_SMA_Standard" {
	Properties {
		_MainTex ("Albedo", 2D) = "white" {}
		_TintColour ("Tint Colour", Vector) = (1,0,0,0)
		_TintMaskIntensity ("Tint Mask Intensity", Range(0, 1)) = 1
		_ETHEmissiveTintHeight ("ETH (Emissive, Tint, Height)", 2D) = "white" {}
		_SMASmoothnessMetallicAO ("SMA (Smoothness, Metallic, AO)", 2D) = "white" {}
		_SmoothnessIntensity ("Smoothness Intensity", Range(-20, 20)) = 1
		_MetallicIntensity ("Metallic Intensity", Range(-20, 20)) = 1
		_Normal ("Normal", 2D) = "bump" {}
		_DetailNormal ("Detail Normal", 2D) = "bump" {}
		_DetailTiling ("Detail Tiling", Range(-20, 20)) = 1
		_EmissiveColor ("Emissive Color", Vector) = (0,0,0,0)
		_EmissiveIntensity ("Emissive Intensity", Range(0, 20)) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}