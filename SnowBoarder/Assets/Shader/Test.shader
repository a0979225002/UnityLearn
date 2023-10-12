Shader "Test"
{
	Properties
	{
		_MainTex ("MainTex", 2D) = "white" {}
                _IlmTex ("IlmTex", 2D) = "white" {}

		[Space(20)]
		_MainColor("Main Color", Color) = (1,1,1)
		_ShadowColor ("Shadow Color", Color) = (0.7, 0.7, 0.7)
		_ShadowSmooth("Shadow Smooth", Range(0, 0.03)) = 0.002
		_ShadowRange ("Shadow Range", Range(0, 1)) = 0.6

		[Space(20)]
		_SpecularColor("Specular Color", Color) = (1,1,1)
		_SpecularRange ("Specular Range",  Range(0, 1)) = 0.9
                _SpecularMulti ("Specular Multi", Range(0, 1)) = 0.4
		_SpecularGloss("Sprecular Gloss", Range(0.001, 8)) = 4

		[Space(20)]
		_OutlineWidth ("Outline Width", Range(0, 1)) = 0.24
                _OutLineColor ("OutLine Color", Color) = (0.5,0.5,0.5,1)
	}

	SubShader
	{
		Pass
		{
			Tags { "LightMode"="ForwardBase"}

			CGPROGRAM
                        #pragma vertex vert
                        #pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
                        #include "AutoLight.cginc"

                        sampler2D _MainTex;
			float4 _MainTex_ST;
                        sampler2D _IlmTex;
			float4 _IlmTex_ST;

			half3 _MainColor;
			half3 _ShadowColor;
			half _ShadowSmooth;
			half _ShadowRange;

			half3 _SpecularColor;
			half _SpecularRange;
        	        half _SpecularMulti;
			half _SpecularGloss;

			struct a2v
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
			};

			v2f vert (a2v v)
			{
				v2f o = (v2f)0;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				return o;
			}

			half4 frag (v2f i) : SV_Target
			{
				half4 col = 0;
				half4 mainTex = tex2D (_MainTex, i.uv);
				half4 ilmTex = tex2D (_IlmTex, i.uv);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
				half3 worldNormal = normalize(i.worldNormal);
				half3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

				half3 diffuse = 0;
				half halfLambert = dot(worldNormal, worldLightDir) * 0.5 + 0.5;
				half threshold = (halfLambert + ilmTex.g) * 0.5;
				half ramp = saturate(_ShadowRange  - threshold);
				ramp =  smoothstep(0, _ShadowSmooth, ramp);
				diffuse = lerp(_MainColor, _ShadowColor, ramp);
				diffuse *= mainTex.rgb;

				half3 specular = 0;
				half3 halfDir = normalize(worldLightDir + viewDir);
				half NdotH = max(0, dot(worldNormal, halfDir));
				half SpecularSize = pow(NdotH, _SpecularGloss);
				half specularMask = ilmTex.b;
				if (SpecularSize >= 1 - specularMask * _SpecularRange)
				{
					specular = _SpecularMulti * (ilmTex.r) * _SpecularColor;
				}

				col.rgb = (diffuse + specular) * _LightColor0.rgb;
				return col;
			}
			ENDCG
		}

                Pass
                {
                        //描边，参考上一篇
                }
	}
	FallBack Off
}
