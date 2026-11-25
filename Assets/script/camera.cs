using UnityEngine;
using UnityEngine.InputSystem;
public class camera : MonoBehaviour
{
    [Header("mOVIMENTO")]
    [SerializeField] private float velocidade = 5f;
    [SerializeField, Range(1f, 4f)] private float multiplicadorCorrida = 2f;

    [Header("Limites da fase")]
    [SerializeField] private Vector2 LimiteMin = new Vector2(-10f, -5f);
    [SerializeField] private Vector2 limiteMax = new Vector2(30f, 10f);

    [Header("Zoom")]
    [SerializeField, Range(0.5f, 2f)] private float passoZoom = 1f;
    [SerializeField] private float zoomMin = 3f;
    [SerializeField] private float zoomMax = 10f;
    private InputAction mover;
    private InputAction correr;
    private Camera cam;

    void Awake() 
    {
        cam = GetComponent<Camera>();
        mover = InputSystem.actions.FindAction("Move");
        correr = InputSystem.actions.FindAction("Sprint");
    }

    void Update() 
    {
        Mover();
        Zoom();
    }

    void Mover() 
    {
        Vector2 direcao = mover.ReadValue<Vector2>();
        float vel = velocidade;
        if (correr.IsPressed()) { vel *= multiplicadorCorrida; }

        Vector3 pos = transform.position + (Vector3)(direcao * vel * Time.deltaTime);
        pos.x = Mathf.Clamp(pos.x, LimiteMin.x, limiteMax.x);
        pos.y = Mathf.Clamp(pos.y, LimiteMin.y, limiteMax.y);
        transform.position = pos;
    }

    void Zoom() 
    {
        float rolagem = Mouse.current.scroll.ReadValue().y;
        if (rolagem != 0f) {
            float passo = Mathf.Sign(rolagem) * passoZoom;
            float novo = cam.orthographicSize - passo;
            cam.orthographicSize = Mathf.Clamp(novo, zoomMin, zoomMax);
        }
    }
}    
 