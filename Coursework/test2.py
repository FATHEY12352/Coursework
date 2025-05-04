import math

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

def orientation(p, q, r):
    val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y)
    if val == 0:
        return 0  # Collinear
    elif val > 0:
        return 1  # Clockwise
    else:
        return 2  # Counterclockwise

def jarvis_hull(points):
    n = len(points)
    if n < 3:
        return points

    l = 0
    for i in range(1, n):
        if points[i].x < points[l].x:
            l = i
        elif points[i].x == points[l].x and points[i].y < points[l].y:
            l = i

    hull = []
    p = l
    q = 0
    while(True):
        hull.append(points[p])
        q = (p + 1) % n
        for i in range(n):
            if orientation(points[p], points[i], points[q]) == 2:
                q = i
        p = q
        if (p == l):
            break
    return hull

# Пример использования
points = [Point(0, 3), Point(2, 3), Point(4, 4), Point(0, 0),
          Point(1, 1), Point(2, 1), Point(3, 0), Point(3, 3)]
convex_hull = jarvis_hull(points)
print("Выпуклая оболочка:")
for point in convex_hull:
    print(f"({point.x}, {point.y})")
