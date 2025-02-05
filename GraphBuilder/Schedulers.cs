namespace InvokeAI.SDK.GraphBuilder;


public static class Schedulers {
    public static string ddim { get; } = "ddim";
    public static string ddpm { get; } = "ddpm";
    public static string deis { get; } = "deis";
    public static string lms { get; } = "lms";
    public static string lms_k { get; } = "lms_k";
    public static string pndm { get; } = "pndm";
    public static string heun { get; } = "heun";
    public static string heun_k { get; } = "heun_k";
    public static string euler { get; } = "euler";
    public static string euler_k { get; } = "euler_k";
    public static string euler_a { get; } = "euler_a";
    public static string kdpm_2 { get; } = "kdpm_2";
    public static string kdpm_2_a { get; } = "kdpm_2_a";
    public static string dpmpp_2s { get; } = "dpmpp_2s";
    public static string dpmpp_2s_k { get; } = "dpmpp_2s_k";
    public static string dpmpp_2m { get; } = "dpmpp_2m";
    public static string dpmpp_2m_k { get; } = "dpmpp_2m_k";
    public static string dpmpp_2m_sde { get; } = "dpmpp_2m_sde";
    public static string dpmpp_2m_sde_k { get; } = "dpmpp_2m_sde_k";
    public static string dpmpp_sde { get; } = "dpmpp_sde";
    public static string dpmpp_sde_k { get; } = "dpmpp_sde_k";
    public static string unipc { get; } = "unipc";
    public static string lcm { get; } = "lcm";
    public static string tcd { get; } = "tcd";
}