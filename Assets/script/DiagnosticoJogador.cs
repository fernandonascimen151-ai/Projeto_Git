using UnityEngine;
using UnityEngine.InputSystem; 
public class DiagnosticoJogador : MonoBehaviour
{
  [SerializeField] private Color corAlerta = Color.red;
  private SpriteRenderer sprite;
  private Color corOriginal;
  private Vector3 posicaoInicial;
  private InputAction pular;

  void Awake()
  { 
      sprite = GetComponent<SpriteRenderer>(); 
      pular = InputSystem.actions.FindAction("Jump");
  }

  void start() 
  {
      corOriginal = sprite.color;
      posicaoInicial = transform.position;
  }

  void Update()
    {
      
      if (Keyboard.current.cKey.wasPressedThisFrame) 
      {
          sprite.color = corAlerta;
          sprite.color = (sprite.color == corAlerta) ? corOriginal : corAlerta;
          Debug.Log("Cor do jogador alterada");
      }

      if (Keyboard.current.pKey.wasPressedThisFrame) 
      {
          Debug.Log($"Posição: {transform.position}");
      }

      if (Keyboard.current.rKey.wasPressedThisFrame) 
      {
          transform.position = posicaoInicial;
          Debug.Log("jogador voltou ao início");
      }

      if (pular.WasPressedThisFrame()) 
      {
          Debug.Log("pulo detectado");
      }
   }
}
