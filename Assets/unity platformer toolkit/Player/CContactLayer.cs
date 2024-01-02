using UnityEngine;

public class CContactLayer : MonoBehaviour
{
    [Header("Contact Layer Params")]
    [SerializeField] private float radius = 0.3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Vector2 offset = Vector2.zero;

    /// <summary>
    /// ��������, ������� ��������� ������
    /// </summary>
    public bool IsGrounded 
    { 
        get 
        { 
            return GetGrounded(); 
        } 
    }

    /// <summary>
    /// �����, ������� ��������� ����������� �������� �� ��������������� � ������� �����
    /// </summary>
    /// <returns>������������� �� ������� ������ �� �����</returns>
    private bool GetGrounded()
    {
        Vector2 position = new Vector2(
            transform.position.x + offset.x,
            transform.position.y + offset.y
        );

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layer);

        return colliders.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 position = new Vector2(
            transform.position.x + offset.x,
            transform.position.y + offset.y
        );

        Gizmos.DrawSphere(position, radius);
    }
}
