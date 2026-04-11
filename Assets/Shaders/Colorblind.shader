Shader "Custom/Simple_Filter"
{
    Properties
    {
        [HideInInspector] _MainTex ("Texture", 2D) = "white" {}
        type ("Type", Int) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        ZWrite Off Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            int type;

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // IMPORTANT: Aquí agafem el que hi ha "sota" del filtre
                // Però com que és una Raw Image, el shader del plugin original 
                // necessita les matrius. Les tornem a posar aquí:
                float3x3 m[4] = {
                    float3x3(1,0,0, 0,1,0, 0,0,1), // Normal
                    float3x3(0.567,0.433,0, 0.558,0.442,0, 0,0.242,0.758), // Protanopia
                    float3x3(0.625,0.375,0, 0.7,0.3,0, 0,0.3,0.7), // Deuteranopia
                    float3x3(0.95,0.05,0, 0,0.433,0.567, 0,0.475,0.525) // Tritanopia
                };

                // Com que volem que sigui un filtre que deixi veure la càmera:
                // Si el shader de la Raw Image no rep la càmera, haurem de fer un truc.
                return fixed4(0,0,0,0); // Ara l'arreglem a baix
            }
            ENDCG
        }
    }
}