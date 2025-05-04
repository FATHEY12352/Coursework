import matplotlib.pyplot as plt
import time
import os  # مكتبة للتعامل مع نظام الملفات

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

def orientation(p, q, r):
    val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y)
    if val == 0:
        return 0
    elif val > 0:
        return 1
    else:
        return 2

def jarvis_hull_visualized(points, output_dir="plots"):
    """
    تقوم هذه الدالة بحساب الغلاف المحدب لمجموعة من النقاط وتصور العملية خطوة بخطوة.
    بالإضافة إلى ذلك، تقوم بحفظ كل رسم بياني كصورة PNG في الدليل المحدد،
    وإرجاع قائمة بمسارات الصور.

    Args:
        points: قائمة بكائنات Point تمثل النقاط.
        output_dir: (اختياري) الدليل الذي سيتم فيه حفظ الصور. القيمة الافتراضية هي "plots".

    Returns:
        قائمة بمسارات الملفات للصور التي تم إنشاؤها.
    """
    n = len(points)
    if n < 3:
        return points, []

    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    l = 0
    for i in range(1, n):
        if points[i].x < points[l].x:
            l = i
        elif points[i].x == points[l].x and points[i].y < points[l].y:
            l = i

    hull = []
    p = l
    q = 0
    image_paths = []
    step = 0
    while True:
        hull.append(points[p])
        plt.figure(figsize=(8, 8))
        all_x = [point.x for point in points]
        all_y = [point.y for point in points]
        plt.scatter(all_x, all_y, color='blue')
        hull_x = [point.x for point in hull]
        hull_y = [point.y for point in hull]
        plt.plot(hull_x, hull_y, color='red', linewidth=2)
        plt.scatter(points[p].x, points[p].y, color='green', s=100)
        plt.title(f"الخطوة: {step}, النقطة الحالية: ({points[p].x}, {points[p].y})")
        plt.xlabel("X")
        plt.ylabel("Y")
        plt.grid(True)

        image_path = os.path.join(output_dir, f"step_{step}.png")
        plt.savefig(image_path)
        image_paths.append(image_path)
        plt.close()

        q = (p + 1) % n
        for i in range(n):
            plt.figure(figsize=(8, 8))
            plt.scatter(all_x, all_y, color='blue')
            plt.plot(hull_x, hull_y, color='red', linewidth=2)
            plt.scatter(points[p].x, points[p].y, color='green', s=100)
            plt.scatter(points[q].x, points[q].y, color='orange', s=100)
            plt.scatter(points[i].x, points[i].y, color='purple', s=100)
            plt.title(f"الخطوة: {step}, فحص النقطة ({points[i].x}, {points[i].y})")
            plt.xlabel("X")
            plt.ylabel("Y")
            plt.grid(True)

            image_path = os.path.join(output_dir, f"step_{step}_checking_{i}.png")
            plt.savefig(image_path)
            image_paths.append(image_path)
            plt.close()

            if orientation(points[p], points[i], points[q]) == 2:
                q = i
        p = q
        if (p == l):
            plt.figure(figsize=(8, 8))
            plt.scatter(all_x, all_y, color='blue')
            hull_x = [point.x for point in hull] + [hull[0].x]
            hull_y = [point.y for point in hull] + [hull[0].y]
            plt.plot(hull_x, hull_y, color='red', linewidth=2)
            plt.scatter(points[p].x, points[p].y, color='green', s=100)
            plt.title("الغلاف المحدب النهائي")
            plt.xlabel("X")
            plt.ylabel("Y")
            plt.grid(True)
            image_path = os.path.join(output_dir, f"final_hull.png")
            plt.savefig(image_path)
            image_paths.append(image_path)
            plt.close()
            break
        step += 1
    return hull, image_paths


# Пример использования с визуализацией и сохранением
points = [Point(0, 3), Point(2, 3), Point(4, 4), Point(0, 0),
          Point(1, 1), Point(2, 1), Point(3, 0), Point(3, 3)]
output_directory = "convex_hull_images"
convex_hull, image_paths = jarvis_hull_visualized(points, output_directory)

# Print file paths
print("Generated images and saved in directory:", output_directory)
for path in image_paths:
    print(path)

print("Convex Hull Points:")
for point in convex_hull:
    print(point)
