using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMoveController : MoveController {
    private Transform _transform;
    // out settings bezier curv
    private WaveController waveController;
    private float speed = 23f;
    [Header("segment per curve")] private int smooth = 20;
    private readonly List<Vector3> bezierPath = new List<Vector3>();
    private float rotateSpeed = 10.0f;
    private float reachDist = 1.0f;

    private void Awake() {
        _transform = GetComponent<Transform>();
        waveController = Singleton<WaveController>.Instance;
    }

    public override void Move(EnemiesEntity e, float time) {
        StartCoroutine(PathBezierCurve(e, smooth));
    }

    private IEnumerator MoveToPoint(EnemiesEntity e) {
#if UNITY_EDITOR
       DrawBezier();
#endif
        int count = bezierPath.Count;
        for (int i = 0; i < count - 1; i++) {
            Vector3 end_pos = bezierPath[i];
            while (true) {
                yield return new WaitForFixedUpdate();

                float distance = Vector3.Distance(end_pos, _transform.position);
                _transform.position = Vector3.MoveTowards(_transform.position, end_pos, speed * Time.deltaTime);
                Vector3 dest = (end_pos - _transform.position).normalized;
                float angle = VectorUtil.GetAngle(Vector3.down, dest) * Mathf.Rad2Deg;
                _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.Euler(0, 0, angle),
                    rotateSpeed * Time.deltaTime);
                if (distance <= reachDist) {
                    break;
                }
            }
        }
        e.flagOutOfScreen = true;
    }
#if UNITY_EDITOR
    private void DrawBezier() {
      //  if (bezierPath.Count==0) return;
        Vector3 firstPoint = bezierPath[0];
        bezierPath.ForEach(p => {
            Debug.DrawLine(firstPoint, p, Color.green, 100);
            firstPoint = p;
        });
    }
#endif

    public IEnumerator PathBezierCurve(EnemiesEntity e, int count_points) {
        bezierPath.Clear();
        var positions = waveController._positions;
        var size = positions.Length;
        for (int i = 0; i < size - 3; i += 3) {
            Vector3 p0 = positions[i];
            Vector3 p1 = positions[i + 1];
            Vector3 p2 = positions[i + 2];
            Vector3 p3 = positions[i + 3];
            if (i == 0) {
                bezierPath.Add(BezierCurve.CubicBezier(0, p0, p1, p2, p3));
            }
            for (int J = 1; J <= count_points; J++) {
                float t = J / (float) count_points;
                bezierPath.Add(BezierCurve.CubicBezier(t, p0, p1, p2, p3));
                yield return null;
            }
        }
        StartCoroutine(MoveToPoint(e));
    }
}