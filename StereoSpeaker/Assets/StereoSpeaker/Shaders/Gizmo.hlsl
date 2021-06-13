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

float4 _Color;
float _Line;
float _MinAlpha;

static const float PI = 3.14159;

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}

float4 frag(v2f i) : SV_Target
{
    float x = frac(i.uv.x * 4);
    float y = i.uv.y - 0.5;
    float l = _Line;
    float cy = step(-l, y) * (1 - step(l, y));
    float lx = l * 2 / cos(y * PI);
    float cx = step(1-lx, x) + (1 - step(lx, x));
    float4 col = _Color;
    float c = clamp(cx + cy, 0, 1);
    col.a *= c;
    col.a = max(col.a, _MinAlpha);
    return col;
}