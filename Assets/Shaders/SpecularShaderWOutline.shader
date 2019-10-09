Shader "SpecularShaderWOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AmbientRatio ("Ambient Ratio", Range(0, 1)) = 0.5
        _AmbientColour ("Ambient Colour", Color) = (0, 0, 0, 1)
        _DiffuseRatio ("Diffuse Ratio", Range(0, 1)) = 0.5
        _DiffuseColour ("Diffuse Colour", Color) = (0.5, 0.5, 0.5, 1)
        _SpecularRatio ("Specular Ratio", Range(0, 1)) = 0.5
        _SpecularColour ("Specular Colour", Color) = (1, 1, 1, 1)
        _SpecularIntensity ("Specular Intensity", Range(1, 50)) = 1
        _OutlineColour ("Outline Colour", Color) = (0, 0, 0, 1)
        _UnlitOutlineThickness ("Unlite Outline Thickness", Range(0, 10)) = 1
        _LitOutlineThickness ("Lit Outline Thickness", Range(0, 10)) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"


            struct v2f
            {
                float4 vertex : SV_POSITION;
                half3 worldNormal : NORMAL;
                float4 posWorld : TEXCOORD1;

            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _AmbientColour;
            float4 _DiffuseColour;
            float4 _SpecularColour;
            float _SpecularRatio;
            float _SpecularIntensity;
            float _AmbientRatio;
            float _DiffuseRatio;
            float4 _OutlineColour;
            float4 _Terrain0;
            float4 _Terrain1;
            float4 _Terrain2;
            float4 _Terrain3;
            float4 _Terrain4;
            float _MinHeight;
            float _MaxHeight;
            float _UnlitOutlineThickness;
            float _LitOutlineThickness;

            v2f vert (float4 vertex : POSITION, float3 normal : NORMAL)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(vertex);
                o.worldNormal =normalize(mul(float4(normal, 0.0), unity_WorldToObject).xyz);
                o.posWorld = mul(unity_ObjectToWorld, vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                                
                // calculate lighting
                float3 ambient = _AmbientRatio * _AmbientColour;
                float3 N = normalize(i.worldNormal);
                float D = dot(_WorldSpaceLightPos0, i.worldNormal);
                float3 diffuse = _DiffuseColour.rgb * max(0, D) * _DiffuseRatio;
                float3 lightDirection = _WorldSpaceLightPos0.xyz - i.posWorld.xyz * _WorldSpaceLightPos0.w;
                float3 R = reflect(-lightDirection, N);
                float3 V = normalize(_WorldSpaceCameraPos - i.posWorld.xyz);
                float3 specular;
                if (dot(i.worldNormal, lightDirection) < 0.0) {
                    specular = float3(0,0,0);
                } else {
                    specular = _SpecularRatio * pow(max(0, dot(R, V)), _SpecularIntensity) * _SpecularColour.rgb;
                }
                
                fixed3 col = ambient + diffuse + specular;
                
                if (dot(V, N) 
                   < lerp(_UnlitOutlineThickness, _LitOutlineThickness, 
                   max(0.0, dot(N, lightDirection))))
                {
                   col = _OutlineColour.rgb; 
                }
                
                return float4(col, 1);
            }
            ENDCG
        }
    }
}