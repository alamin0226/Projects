#include <windows.h>
#include <GL/glut.h>
#include <cmath>
#include <mmsystem.h>
#pragma comment(lib, "winmm.lib")

float carX = -200.0f;
float car2X = 1700.0f;

char environmentMode = 'n';
int environmentFrame = 0;

const float BUILDING_Y = 520.0f;


float student1X = 135.0f;
float student1Y = 610.0f;

float student2X = 165.0f;
float student2Y = 610.0f;

bool showStudents = true;
bool crashed = false;

bool startByKeyboard = false;

bool accidentSoundPlayed = false;
bool ambulanceSoundPlayed = false;
bool sadSoundPlayed = false;
int crashSoundCounter = 0;

bool showAmbulance = false;
bool ambulanceReached = false;
float ambulanceX = 715.0f;
float ambulanceY = 550.0f;
float ambulanceTargetX = 700.0f;

bool ambulanceOnHospitalRoad = false;

int accidentAfterCounter = 0;

float crashedRedCarX = 0.0f;
float crashedBlueCarX = 0.0f;
float crashedRedCarY = 280.0f;
float crashedBlueCarY = 280.0f;

// Dead body position fixed at collision spot
float deadBodyX = 0.0f;
float deadBodyY = 260.0f;

float redCarAngle = 0.0f;
float blueCarAngle = 0.0f;

bool showDeadBody = false;
bool showHospitalInside = false;

float hospitalTrolleyX = -250.0f;
bool trolleyReachedICU = false;
bool patientInsideICU = false;

bool allowPatientEnterICU = false;

int patientEnterCounter = 0;

float hospitalDoctorX = 1540.0f;
bool doctorStartRunning = false;
bool doctorReachedICU = false;
// Doctor mouse speed control
bool doctorMousePressed = false;

float doctorSpeed = 0.0f;         // current speed
float doctorMinSpeed = 1.5f;      // click na korleo doctor slow cholbe
float doctorMaxSpeed = 18.0f;     // maximum speed

float doctorAcceleration = 0.45f; // click hold korle speed barar rate
float doctorFriction = 0.25f;     // click chere dile speed komar rate

// Scene states:
// 0 = red car coming from left to school
// 1 = red car stopped in front of school
// 2 = students going to car
// 3 = students entered car, waiting for S key
// 4 = red car starts again, blue car comes from right
// 5 = collision and ambulance scene
int sceneState = 0;
int waitCounter = 0;

float schoolStopX = 120.0f;

// ---------------- SOUND FUNCTIONS ----------------
void playAccidentSound() {
    PlaySound(TEXT("accident.wav"), NULL, SND_FILENAME | SND_ASYNC | SND_NODEFAULT);
}

void playAmbulanceSound() {
    PlaySound(TEXT("ambulance.wav"), NULL, SND_FILENAME | SND_ASYNC | SND_NODEFAULT);
}

void playSadSound() {
    PlaySound(TEXT("sad.wav"), NULL, SND_FILENAME | SND_ASYNC | SND_NODEFAULT);
}

// ---------------- BASIC DRAWING FUNCTIONS ----------------
void drawRectangle(float x, float y, float width, float height, float red, float green, float blue) {
    glColor3f(red, green, blue);
    glBegin(GL_QUADS);
        glVertex2f(x, y);
        glVertex2f(x + width, y);
        glVertex2f(x + width, y + height);
        glVertex2f(x, y + height);
    glEnd();
}

void drawCircle(float cx, float cy, float radius, float red, float green, float blue) {
    glColor3f(red, green, blue);
    glBegin(GL_TRIANGLE_FAN);
        glVertex2f(cx, cy);
        for (int i = 0; i <= 360; i += 5) {
            float angle = i * 3.1416f / 180.0f;
            glVertex2f(cx + cos(angle) * radius, cy + sin(angle) * radius);
        }
    glEnd();
}

void drawEllipse(float cx, float cy, float rx, float ry, float r, float g, float b) {
    glColor3f(r, g, b);
    glBegin(GL_TRIANGLE_FAN);
        glVertex2f(cx, cy);
        for (int i = 0; i <= 360; i += 5) {
            float angle = i * 3.1416f / 180.0f;
            glVertex2f(cx + cos(angle) * rx, cy + sin(angle) * ry);
        }
    glEnd();
}

void drawText(float x, float y, const char* text) {
    if (showHospitalInside) {
        glColor3f(0.0f, 0.0f, 0.0f);
    }
    else if (environmentMode == 'n') {
        glColor3f(1.0f, 1.0f, 1.0f);
    }
    else {
        glColor3f(0.0f, 0.0f, 0.0f);
    }

    glRasterPos2f(x, y);

    for (int i = 0; text[i] != '\0'; i++) {
        glutBitmapCharacter(GLUT_BITMAP_HELVETICA_18, text[i]);
    }
}

void drawTextBlack(float x, float y, const char* text) {
    glColor3f(0.0f, 0.0f, 0.0f);
    glRasterPos2f(x, y);

    for (int i = 0; text[i] != '\0'; i++) {
        glutBitmapCharacter(GLUT_BITMAP_HELVETICA_18, text[i]);
    }
}

void drawWindow(float x, float y, float w, float h) {
    drawRectangle(x - 2, y - 2, w + 4, h + 4, 0.25f, 0.25f, 0.25f);//border of window

    if (environmentMode == 'n') {
        drawRectangle(x, y, w, h, 1.0f, 0.90f, 0.25f);
    }
    else {
        drawRectangle(x, y, w, h, 0.60f, 0.85f, 1.0f);
    }

    glColor3f(0.15f, 0.15f, 0.15f);
    glBegin(GL_LINES);
        glVertex2f(x + w / 2, y);
        glVertex2f(x + w / 2, y + h);
        glVertex2f(x, y + h / 2);
        glVertex2f(x + w, y + h / 2);
    glEnd();
}

// ---------------- INSTRUCTION TEXT ----------------
void drawInstructionPanel() {
    if (environmentMode == 'n') {
        glColor3f(1.0f, 1.0f, 1.0f);
    }
    else {
        glColor3f(0.0f, 0.0f, 0.0f);
    }

    drawText(25, 865, "Press D = Day | W = Winter | R = Rainy");

    if (environmentMode == 'n') {
        drawText(25, 835, "Current Scene: Night");
    }
    else if (environmentMode == 'd') {
        drawText(25, 835, "Current Scene: Day");
    }
    else if (environmentMode == 'w') {
        drawText(25, 835, "Current Scene: Winter");
    }
    else if (environmentMode == 'r') {
        drawText(25, 835, "Current Scene: Rainy");
    }

    if (sceneState == 3) {
        drawText(25, 805, "Students entered the car. Press S to start the car.");
    }
    if (sceneState == 5 && ambulanceReached && !showHospitalInside) {
    drawText(25, 805, "Ambulance reached. Click LEFT MOUSE to enter Hospital Emergency Ward.");
    }
}

// ---------------- NIGHT STAR FUNCTIONS ----------------
void drawTwinklingStars() {
    for (int i = 0; i < 65; i++) {
        float x = 40.0f + (i * 97) % 1500;
        float y = 720.0f + (i * 53) % 160;

        float twinkle = sin((environmentFrame + i * 11) * 0.12f);// 0.12f star blinking speed
        float brightness = 0.65f + 0.35f * fabs(twinkle);//color value 0 to 1.0
        float radius = 1.5f + 1.5f * fabs(twinkle);

        drawCircle(x, y, radius, brightness, brightness, brightness);

        if (i % 9 == 0) {
            glColor3f(brightness, brightness, brightness);
            glBegin(GL_LINES);
                glVertex2f(x - 5, y);
                glVertex2f(x + 5, y);
                glVertex2f(x, y - 5);
                glVertex2f(x, y + 5);
            glEnd();
        }
    }
}

void drawCloud(float x, float y, float scale, float r, float g, float b) {
    glPushMatrix();
        glTranslatef(x, y, 0);
        glScalef(scale, scale, 1.0f);

        drawCircle(0, 0, 25, r, g, b);//left side circle
        drawCircle(25, 8, 32, r, g, b);//middle/top large circle
        drawCircle(60, 0, 25, r, g, b);//right side circle
        drawCircle(32, -8, 28, r, g, b);//middle lower circle
        //drawRectangle(-5, -25, 70, 25, r, g, b);

    glPopMatrix();
}

// ---------------- WEATHER EFFECTS ----------------

void drawRainEffect() {

    glColor3f(0.65f, 0.75f, 0.95f);
    glLineWidth(2.0f);


        //120 ta rain drop draw kora hocche.

    for (int i = 0; i < 120; i++) {


        float x = (i * 47) % 1600;
        float y = 900.0f - ((environmentFrame * 12 + i * 31) % 900);//12 rainning speed

        // Ekta rain drop line draw kora hocche
        glBegin(GL_LINES);
            glVertex2f(x, y);
            glVertex2f(x - 12, y - 35);//line ta vertical korar jonno minus kora hoyese
        glEnd();
    }

    glLineWidth(1.0f);
}


void drawSnowEffect() {

       // 90 ta snowflake draw kora hocche.

    for (int i = 0; i < 90; i++) {

        float x = (i * 61 + environmentFrame * 2) % 1600;
        float y = 900.0f - ((environmentFrame * 4 + i * 37) % 900);

        drawCircle(x, y, 3.0f, 1.0f, 1.0f, 1.0f);
    }
}


void drawWeatherOverlay() {

    if (environmentMode == 'r') {

        drawCloud(150, 820, 1.1f, 0.35f, 0.35f, 0.38f);
        drawCloud(520, 800, 1.3f, 0.32f, 0.32f, 0.35f);
        drawCloud(950, 830, 1.15f, 0.36f, 0.36f, 0.40f);
        drawCloud(1280, 795, 1.25f, 0.30f, 0.30f, 0.33f);

        // Cloud-er pore rain effect draw kora hocche
        drawRainEffect();
    }
    else if (environmentMode == 'w') {
        /*
            Winter mode-er jonno light white/bluish clouds draw kora hocche.
            Rainy cloud dark, winter cloud light color.
        */
        drawCloud(180, 825, 1.0f, 0.92f, 0.95f, 1.0f);
        drawCloud(620, 810, 1.2f, 0.90f, 0.94f, 1.0f);
        drawCloud(1100, 835, 1.1f, 0.92f, 0.95f, 1.0f);

        // Cloud-er pore snow effect draw kora hocche
        drawSnowEffect();
    }
}

// ---------------- TREE DRAWING ----------------
void drawTree(float x, float y, float scale) {
    glPushMatrix();
        glTranslatef(x, y, 0);
        glScalef(scale, scale, 1.0f);

        drawEllipse(0, -5, 45, 12, 0.05f, 0.25f, 0.07f);//Ground shadow

        drawRectangle(-12, 0, 24, 85, 0.42f, 0.22f, 0.08f);//Main trunk/brown trunk
        drawRectangle(2, 0, 10, 85, 0.30f, 0.14f, 0.05f); //Dark side/shading

        glColor3f(0.18f, 0.08f, 0.03f);
        glLineWidth(2.0f);
        glBegin(GL_LINES);//texture line
            glVertex2f(-5, 12);
            glVertex2f(-2, 35);

            glVertex2f(5, 20);
            glVertex2f(2, 55);

            glVertex2f(-8, 45);
            glVertex2f(-4, 75);
        glEnd();

        glLineWidth(1.0f);

        if (environmentMode == 'w') {
            drawEllipse(-35, 115, 45, 38, 0.72f, 0.84f, 0.88f);//icy color
            drawEllipse(35, 115, 45, 38, 0.72f, 0.84f, 0.88f);
            drawEllipse(0, 140, 55, 45, 0.78f, 0.88f, 0.92f);
            drawEllipse(-10, 100, 55, 35, 0.68f, 0.80f, 0.86f);
            drawEllipse(10, 105, 55, 35, 0.68f, 0.80f, 0.86f);

            drawEllipse(-30, 160, 35, 22, 1.0f, 1.0f, 1.0f);//white leafs like snow
            drawEllipse(30, 160, 35, 22, 1.0f, 1.0f, 1.0f);
            drawEllipse(0, 180, 38, 24, 1.0f, 1.0f, 1.0f);
        }
        else if (environmentMode == 'n') {
            drawEllipse(-35, 115, 45, 38, 0.02f, 0.18f, 0.05f);
            drawEllipse(35, 115, 45, 38, 0.02f, 0.18f, 0.05f);
            drawEllipse(0, 140, 55, 45, 0.03f, 0.22f, 0.06f);
            drawEllipse(-10, 100, 55, 35, 0.02f, 0.16f, 0.04f);
            drawEllipse(10, 105, 55, 35, 0.02f, 0.16f, 0.04f);
        }
        else {
            drawEllipse(-35, 115, 45, 38, 0.05f, 0.32f, 0.08f);//dark green base leaf mass
            drawEllipse(35, 115, 45, 38, 0.05f, 0.32f, 0.08f);
            drawEllipse(0, 140, 55, 45, 0.05f, 0.36f, 0.10f);
            drawEllipse(-10, 100, 55, 35, 0.04f, 0.28f, 0.07f);
            drawEllipse(10, 105, 55, 35, 0.04f, 0.28f, 0.07f);

            drawEllipse(-45, 135, 38, 32, 0.08f, 0.48f, 0.12f);//brighter leaf layers
            drawEllipse(45, 135, 38, 32, 0.08f, 0.48f, 0.12f);
            drawEllipse(0, 165, 48, 38, 0.10f, 0.55f, 0.15f);
            drawEllipse(-22, 150, 42, 34, 0.07f, 0.45f, 0.11f);
            drawEllipse(22, 150, 42, 34, 0.07f, 0.45f, 0.11f);

            drawEllipse(-25, 165, 25, 20, 0.20f, 0.65f, 0.20f);//highlight leaves
            drawEllipse(25, 165, 25, 20, 0.20f, 0.65f, 0.20f);
            drawEllipse(0, 185, 28, 22, 0.25f, 0.75f, 0.25f);
            drawEllipse(-50, 145, 18, 15, 0.18f, 0.60f, 0.18f);
            drawEllipse(50, 145, 18, 15, 0.18f, 0.60f, 0.18f);

            drawCircle(-20, 150, 5, 0.85f, 0.05f, 0.04f);//Fruits draw
            drawCircle(28, 138, 5, 0.85f, 0.05f, 0.04f);
            drawCircle(10, 175, 4, 0.90f, 0.10f, 0.05f);
        }

    glPopMatrix();
}

// ADD RANGE:
// drawTree(...) function er pore ei function ta add korbe.
// Existing drawTree function tomar code e already ache. :contentReference[oaicite:0]{index=0}

void drawBottomAsymmetricTrees() {
    // gari je main road diye chole, tar niche green field area te trees
    // y range mainly 25 to 170 er moddhe rakha hoise, jate main road er sathe overlap na kore

    drawTree(60, 40, 0.35f);
    drawTree(145, 95, 0.48f);
    drawTree(245, 35, 0.38f);
    drawTree(360, 120, 0.55f);
    drawTree(470, 55, 0.42f);
    drawTree(590, 135, 0.50f);
    drawTree(720, 45, 0.36f);
    drawTree(850, 115, 0.54f);
    drawTree(970, 35, 0.40f);
    drawTree(1085, 130, 0.58f);
    drawTree(1210, 60, 0.44f);
    drawTree(1335, 145, 0.52f);
    drawTree(1460, 40, 0.38f);
    drawTree(1550, 105, 0.46f);
}

void drawTopStraightRoadTrees() {
    // School theke Hospital straight road-er top side
    drawTree(300, 650, 0.38f);
    drawTree(475, 665, 0.42f);
    drawTree(650, 650, 0.38f);

    // Hospital theke Police Station straight road-er top side
    drawTree(930, 650, 0.38f);
    drawTree(1110, 665, 0.42f);
    drawTree(1290, 650, 0.38f);
}


void drawDecorativeGrassLand() {
    float baseR, baseG, baseB;
    float lightR, lightG, lightB;
    float darkR, darkG, darkB;

    if (environmentMode == 'w') {
        baseR = 0.84f; baseG = 0.90f; baseB = 0.86f;
        lightR = 0.92f; lightG = 0.96f; lightB = 0.93f;
        darkR = 0.74f; darkG = 0.82f; darkB = 0.76f;
    }
    else if (environmentMode == 'r') {
        baseR = 0.05f; baseG = 0.34f; baseB = 0.09f;
        lightR = 0.09f; lightG = 0.44f; lightB = 0.14f;
        darkR = 0.03f; darkG = 0.24f; darkB = 0.07f;
    }
    else if (environmentMode == 'n') {
        baseR = 0.03f; baseG = 0.20f; baseB = 0.06f;
        lightR = 0.05f; lightG = 0.28f; lightB = 0.09f;
        darkR = 0.02f; darkG = 0.13f; darkB = 0.04f;
    }
    else {
        baseR = 0.10f; baseG = 0.55f; baseB = 0.16f;
        lightR = 0.18f; lightG = 0.68f; lightB = 0.22f;
        darkR = 0.06f; darkG = 0.40f; darkB = 0.10f;
    }

    // Upper area around school, hospital and police station
    drawRectangle(0, 420, 1600, 80, baseR, baseG, baseB);//First upper strip
    drawRectangle(0, 655, 1600, 50, baseR, baseG, baseB);//Second upper strip

    // Soft rolling grass fields in middle area
    drawEllipse(150, 500, 210, 85, baseR, baseG, baseB);
    drawEllipse(420, 505, 270, 90, lightR, lightG, lightB);
    drawEllipse(780, 510, 180, 78, baseR, baseG, baseB);
    drawEllipse(1125, 500, 285, 92, lightR, lightG, lightB);
    drawEllipse(1450, 490, 185, 82, baseR, baseG, baseB);

    // Darker layers for depth
    drawEllipse(165, 465, 160, 48, darkR, darkG, darkB);
    drawEllipse(520, 470, 180, 52, darkR, darkG, darkB);
    drawEllipse(790, 468, 110, 45, darkR, darkG, darkB);
    drawEllipse(1095, 465, 175, 50, darkR, darkG, darkB);
    drawEllipse(1410, 455, 150, 45, darkR, darkG, darkB);

    // Small lawn patches near top road
    drawEllipse(230, 675, 120, 28, lightR, lightG, lightB);
    drawEllipse(570, 675, 150, 30, lightR, lightG, lightB);
    drawEllipse(1030, 675, 150, 30, lightR, lightG, lightB);
    drawEllipse(1370, 675, 120, 28, lightR, lightG, lightB);

    // Decorative grass in lower field area for more attractive look
    drawEllipse(135, 205, 120, 34, lightR, lightG, lightB);
    drawEllipse(385, 185, 145, 36, darkR, darkG, darkB);
    drawEllipse(690, 210, 125, 34, lightR, lightG, lightB);
    drawEllipse(980, 185, 150, 38, darkR, darkG, darkB);
    drawEllipse(1285, 205, 130, 36, lightR, lightG, lightB);
    drawEllipse(1495, 180, 95, 30, darkR, darkG, darkB);
}
// ---------------- BEZIER ROAD ----------------
void getBezierPoint(
    float t,
    float x0, float y0,
    float x1, float y1,
    float x2, float y2,
    float x3, float y3,
    float &x, float &y
) {
    float u = 1.0f - t;

    x = (u * u * u * x0)
      + (3 * u * u * t * x1)
      + (3 * u * t * t * x2)
      + (t * t * t * x3);

    y = (u * u * u * y0)
      + (3 * u * u * t * y1)
      + (3 * u * t * t * y2)
      + (t * t * t * y3);
}

void drawBezierRoad(
    float x0, float y0,
    float x1, float y1,
    float x2, float y2,
    float x3, float y3
) {
    float x, y;

    if (environmentMode == 'w') {
        glColor3f(0.70f, 0.75f, 0.78f);//light gray, snow/ice road look
    }
    else if (environmentMode == 'r') {
        glColor3f(0.04f, 0.04f, 0.05f);//very dark, wet road look
    }
    else {
        glColor3f(0.10f, 0.10f, 0.12f);//normal dark road border
    }

    //Outer road border draw

    glLineWidth(46.0f);
    glBegin(GL_LINE_STRIP);
        for (int i = 0; i <= 100; i++) {
            float t = i / 100.0f;
            getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
            glVertex2f(x, y);
        }
    glEnd();


    //Main road color set
    if (environmentMode == 'w') {
        glColor3f(0.82f, 0.86f, 0.88f);//light snowy/icy
    }
    else if (environmentMode == 'r') {
        glColor3f(0.12f, 0.12f, 0.14f);//wet dark gray
    }
    else {
        glColor3f(0.24f, 0.24f, 0.26f);//asphalt gray
    }

    //Main road draw
    glLineWidth(36.0f);
    glBegin(GL_LINE_STRIP);
        for (int i = 0; i <= 100; i++) {
            float t = i / 100.0f;
            getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
            glVertex2f(x, y);
        }
    glEnd();

    glColor3f(1.0f, 1.0f, 1.0f);//middle dashed line
    glLineWidth(4.0f);

    //Dashed line draw
    for (int i = 0; i < 100; i += 12) {
        glBegin(GL_LINE_STRIP);
            for (int j = i; j <= i + 6 && j <= 100; j++) {
                float t = j / 100.0f;
                getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
                glVertex2f(x, y);
            }
        glEnd();
    }

    glLineWidth(1.0f);
}


void drawBezierGrassRoad(
    float x0, float y0,
    float x1, float y1,
    float x2, float y2,
    float x3, float y3,
    float roadWidth,
    float grassWidth
) {
    float x, y;

    // road side grass
    if (environmentMode == 'w') {
        glColor3f(0.85f, 0.92f, 0.88f);
    }
    else if (environmentMode == 'r') {
        glColor3f(0.03f, 0.28f, 0.08f);
    }
    else if (environmentMode == 'n') {
        glColor3f(0.02f, 0.16f, 0.05f);
    }
    else {
        glColor3f(0.08f, 0.55f, 0.14f);
    }

    glLineWidth(roadWidth + grassWidth);
    glBegin(GL_LINE_STRIP);
        for (int i = 0; i <= 100; i++) {
            float t = i / 100.0f;
            getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
            glVertex2f(x, y);
        }
    glEnd();

    // outer dark road border
    if (environmentMode == 'w') {
        glColor3f(0.62f, 0.67f, 0.70f);
    }
    else if (environmentMode == 'r') {
        glColor3f(0.03f, 0.03f, 0.04f);
    }
    else {
        glColor3f(0.07f, 0.07f, 0.08f);
    }

    glLineWidth(roadWidth + 10.0f);
    glBegin(GL_LINE_STRIP);
        for (int i = 0; i <= 100; i++) {
            float t = i / 100.0f;
            getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
            glVertex2f(x, y);
        }
    glEnd();

    // main road
    if (environmentMode == 'w') {
        glColor3f(0.78f, 0.82f, 0.84f);
    }
    else if (environmentMode == 'r') {
        glColor3f(0.12f, 0.12f, 0.15f);
    }
    else {
        glColor3f(0.23f, 0.23f, 0.25f);
    }

    glLineWidth(roadWidth);
    glBegin(GL_LINE_STRIP);
        for (int i = 0; i <= 100; i++) {
            float t = i / 100.0f;
            getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
            glVertex2f(x, y);
        }
    glEnd();

    // smooth curved middle dashed line
    // Ei dash gula Bezier road-er curve follow kore bend hobe
    glColor3f(1.0f, 1.0f, 1.0f);
    glLineWidth(4.0f);

    for (float startT = 0.03f; startT < 0.98f; startT += 0.12f) {
        float endT = startT + 0.06f;

        if (endT > 1.0f) {
            endT = 1.0f;
        }

        glBegin(GL_LINE_STRIP);
            for (float t = startT; t <= endT; t += 0.008f) {
                getBezierPoint(t, x0, y0, x1, y1, x2, y2, x3, y3, x, y);
                glVertex2f(x, y);
            }
        glEnd();
    }

    glLineWidth(1.0f);
}

void drawStraightRoad(float x1, float y1, float x2, float y2) {
    if (environmentMode == 'w') {
        glColor3f(0.70f, 0.75f, 0.78f);
    }
    else if (environmentMode == 'r') {
        glColor3f(0.04f, 0.04f, 0.05f);
    }
    else {
        glColor3f(0.10f, 0.10f, 0.12f);
    }

    glLineWidth(46.0f);
    glBegin(GL_LINES);
        glVertex2f(x1, y1);
        glVertex2f(x2, y2);
    glEnd();

    if (environmentMode == 'w') {
        glColor3f(0.82f, 0.86f, 0.88f);
    }
    else if (environmentMode == 'r') {
        glColor3f(0.12f, 0.12f, 0.14f);
    }
    else {
        glColor3f(0.24f, 0.24f, 0.26f);
    }

    glLineWidth(36.0f);
    glBegin(GL_LINES);
        glVertex2f(x1, y1);
        glVertex2f(x2, y2);
    glEnd();

    glColor3f(1.0f, 1.0f, 1.0f);
    glLineWidth(4.0f);

    for (float y = y1; y > y2; y -= 35.0f) {
        glBegin(GL_LINES);
            glVertex2f(x1, y);
            glVertex2f(x1, y - 18.0f);
        glEnd();
    }

    glLineWidth(1.0f);
}

void drawCurvedConnectingRoads() {
    // ================= SCHOOL TO HOSPITAL =================

    // road 1: school theke hospital straight road
    drawBezierGrassRoad(
        155, 610,
        360, 610,
        585, 610,
        790, 610,
        30.0f,
        30.0f
    );

    // road 2: school theke hospital smooth curve road
    drawBezierGrassRoad(
        175, 505,
        390, 430,
        610, 430,
        790, 545,
        24.0f,
        26.0f
    );


    // ================= HOSPITAL TO POLICE STATION =================

    // road 1: hospital theke police station straight road
    drawBezierGrassRoad(
        790, 610,
        1000, 610,
        1220, 610,
        1430, 610,
        30.0f,
        30.0f
    );

    // road 2: hospital theke police station smooth curve road
    drawBezierGrassRoad(
        790, 545,
        970, 430,
        1240, 430,
        1430, 545,
        24.0f,
        26.0f
    );


    // ================= BUILDING TO MAIN ROAD CONNECTORS =================

    // school theke main road connector
    drawBezierGrassRoad(
        155, 575,
        115, 500,
        205, 445,
        155, 380,
        24.0f,
        24.0f
    );

    // hospital theke main road connector
    drawBezierGrassRoad(
        790, 565,
        750, 510,
        830, 440,
        790, 380,
        24.0f,
        24.0f
    );

    // police station theke main road connector
    drawBezierGrassRoad(
        1430, 575,
        1375, 510,
        1490, 440,
        1430, 380,
        24.0f,
        24.0f
    );
}

// ---------------- BUILDINGS ----------------
void drawSchool() {
    drawRectangle(60, 80, 280, 240, 0.82f, 0.90f, 0.95f);// School building-er main body

    glColor3f(0.85f, 0.15f, 0.15f);

    // School-er triangular roof
    glBegin(GL_TRIANGLES);
        glVertex2f(50, 320);
        glVertex2f(200, 390);
        glVertex2f(350, 320);
    glEnd();

    drawRectangle(180, 320, 40, 65, 1.0f, 0.95f, 0.55f);// Roof-er majhkhaner clock tower / upper block draw kora hocche
    drawCircle(200, 350, 15, 1.0f, 1.0f, 1.0f);

    glColor3f(0.0f, 0.0f, 0.0f);
    glBegin(GL_LINES);
        glVertex2f(200, 350);
        glVertex2f(200, 360);
        glVertex2f(200, 350);
        glVertex2f(208, 350);
    glEnd();

    for (int r = 0; r < 3; r++) {
        for (int c = 0; c < 5; c++) {
            drawWindow(80 + c * 50, 120 + r * 60, 35, 42);
        }
    }
    // Main door-er outer frame draw kora hocche
    // Dark brown color
    drawRectangle(170, 80, 60, 70, 0.35f, 0.18f, 0.08f);

    // Door-er left panel draw kora hocche
    // Light brown color
    drawRectangle(174, 80, 25, 65, 0.75f, 0.45f, 0.20f);


    // Door-er right panel draw kora hocche
    // Light brown color
    drawRectangle(202, 80, 25, 65, 0.75f, 0.45f, 0.20f);

    drawText(145, 350, "SCHOOL");
}

void drawHospital() {
    drawRectangle(50, 70, 300, 280, 0.92f, 0.97f, 1.0f);// Hospital building-er main body draw kora hocche

    drawRectangle(180, 350, 40, 15, 1.0f, 0.0f, 0.0f);// Hospital-er top-e red cross er horizontal part draw kora hocche
    drawRectangle(188, 342, 24, 32, 1.0f, 0.0f, 0.0f);// Hospital-er top-e red cross er vertical part draw kora hocche

    for (int r = 0; r < 4; r++) {
        for (int c = 0; c < 6; c++) {
            drawWindow(70 + c * 45, 100 + r * 60, 30, 40);
        }
    }

    // Main entrance-er outer red section draw kora hocche
    drawRectangle(150, 70, 100, 80, 1.0f, 0.0f, 0.0f);

    // Entrance-er inner white section draw kora hocche
    drawRectangle(160, 75, 80, 70, 1.0f, 1.0f, 1.0f);


    // Left glass door/panel draw kora hocche
    drawRectangle(165, 75, 30, 50, 0.82f, 0.90f, 0.95f);

    // Right glass door/panel draw kora hocche
    drawRectangle(205, 75, 30, 50, 0.82f, 0.90f, 0.95f);


    // Hospital building-er name/text draw kora hocche
    drawText(145, 350, "HOSPITAL");;
}

void drawPoliceStation() {
    drawRectangle(60, 80, 280, 260, 0.25f, 0.35f, 0.60f);
    drawRectangle(60, 300, 280, 40, 0.05f, 0.15f, 0.38f);

    drawCircle(200, 320, 18, 1.0f, 0.80f, 0.0f);
    drawCircle(200, 320, 10, 0.05f, 0.15f, 0.38f);

    for (int r = 0; r < 3; r++) {
        for (int c = 0; c < 5; c++) {
            drawWindow(80 + c * 50, 140 + r * 55, 30, 38);
        }
    }

    drawRectangle(160, 80, 80, 70, 0.15f, 0.25f, 0.35f);
    drawRectangle(168, 88, 64, 60, 0.60f, 0.75f, 0.90f);

    drawRectangle(70, 80, 60, 50, 0.35f, 0.35f, 0.35f);
    drawRectangle(270, 80, 60, 50, 0.35f, 0.35f, 0.35f);

    drawText(125, 350, "POLICE");
}

// ---------------- STUDENT AND CARS ----------------
void drawStudent(float x, float y, float shirtR, float shirtG, float shirtB) {
    drawCircle(x, y + 35, 10, 0.95f, 0.75f, 0.55f);//student head
    drawRectangle(x - 8, y + 5, 16, 25, shirtR, shirtG, shirtB);//Student-eer body

    glColor3f(0.0f, 0.0f, 0.0f);
    glBegin(GL_LINES);
        glVertex2f(x - 4, y + 5);
        glVertex2f(x - 8, y - 12);
        glVertex2f(x + 4, y + 5);
        glVertex2f(x + 8, y - 12);
        glVertex2f(x - 8, y + 25);
        glVertex2f(x - 18, y + 12);
        glVertex2f(x + 8, y + 25);
        glVertex2f(x + 18, y + 12);
    glEnd();
}
//red car draw
void drawCar(float x, float y) {
    drawRectangle(x, y, 130, 35, 0.90f, 0.05f, 0.05f);//main red body draw

    glColor3f(0.80f, 0.02f, 0.02f);
    glBegin(GL_POLYGON);//upper cabin/roof
        glVertex2f(x + 25, y + 35);
        glVertex2f(x + 50, y + 65);
        glVertex2f(x + 95, y + 65);
        glVertex2f(x + 115, y + 35);
    glEnd();

    drawRectangle(x + 52, y + 43, 22, 17, 0.60f, 0.85f, 1.0f);//first window draw
    drawRectangle(x + 78, y + 43, 22, 17, 0.60f, 0.85f, 1.0f);//second window

    drawCircle(x + 128, y + 22, 5, 1.0f, 1.0f, 0.50f);//front light/headlight
    drawCircle(x + 3, y + 22, 5, 1.0f, 0.0f, 0.0f);//front/back wheel

    drawCircle(x + 30, y - 2, 14, 0.05f, 0.05f, 0.05f);//front/back wheel-eer ekti black outer wheel।
    drawCircle(x + 100, y - 2, 14, 0.05f, 0.05f, 0.05f);//right wheel-eer black outer part
    drawCircle(x + 30, y - 2, 7, 0.55f, 0.55f, 0.55f);//Left wheel-eer vitore grey circle/rim।
    drawCircle(x + 100, y - 2, 7, 0.55f, 0.55f, 0.55f);//Right wheel-eer vitore grey circle/rim।
}
//blue car draw
void drawCarReverse(float x, float y) {
    drawRectangle(x, y, 130, 35, 0.05f, 0.15f, 0.90f);

    glColor3f(0.02f, 0.08f, 0.80f);
    glBegin(GL_POLYGON);
        glVertex2f(x + 15, y + 35);
        glVertex2f(x + 35, y + 65);
        glVertex2f(x + 80, y + 65);
        glVertex2f(x + 105, y + 35);
    glEnd();

    drawRectangle(x + 30, y + 43, 22, 17, 0.60f, 0.85f, 1.0f);
    drawRectangle(x + 56, y + 43, 22, 17, 0.60f, 0.85f, 1.0f);

    drawCircle(x + 2, y + 22, 5, 1.0f, 1.0f, 0.50f);
    drawCircle(x + 127, y + 22, 5, 1.0f, 0.0f, 0.0f);

    drawCircle(x + 30, y - 2, 14, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 100, y - 2, 14, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 30, y - 2, 7, 0.55f, 0.55f, 0.55f);
    drawCircle(x + 100, y - 2, 7, 0.55f, 0.55f, 0.55f);
}

void drawCrashedRedCar(float x, float y, float angle) {
    glPushMatrix();
        glTranslatef(x + 65, y + 20, 0); // car-er center-e jao
        glRotatef(angle, 0, 0, 1); // center-er around rotate koro
        glTranslatef(-65, -20, 0);// car-ke center-er relative position-e draw koro

        drawCar(0, 0);

        glColor3f(0.0f, 0.0f, 0.0f);
        glLineWidth(3.0f);
        glBegin(GL_LINES);//crack line
            glVertex2f(40, 35);
            glVertex2f(55, 10);
            glVertex2f(80, 35);
            glVertex2f(65, 5);
            glVertex2f(105, 30);
            glVertex2f(125, 15);
        glEnd();
        glLineWidth(1.0f);
    glPopMatrix();
}

void drawCrashedBlueCar(float x, float y, float angle) {
    glPushMatrix();
        glTranslatef(x + 65, y + 20, 0);
        glRotatef(angle, 0, 0, 1);
        glTranslatef(-65, -20, 0);

        drawCarReverse(0, 0);

        glColor3f(0.0f, 0.0f, 0.0f);
        glLineWidth(3.0f);
        glBegin(GL_LINES);
            glVertex2f(35, 30);
            glVertex2f(15, 12);
            glVertex2f(70, 35);
            glVertex2f(85, 8);
            glVertex2f(105, 32);
            glVertex2f(90, 5);
        glEnd();
        glLineWidth(1.0f);
    glPopMatrix();
}

void drawDeadBody(float x, float y) {
    drawCircle(x, y + 8, 9, 0.95f, 0.75f, 0.55f);//head draw
    drawRectangle(x + 8, y + 2, 45, 10, 0.10f, 0.10f, 0.10f);//body

    glColor3f(0.0f, 0.0f, 0.0f);
    glLineWidth(3.0f);
    glBegin(GL_LINES);
        glVertex2f(x + 25, y + 10);//hand
        glVertex2f(x + 35, y + 25);
        glVertex2f(x + 52, y + 7);//top leg
        glVertex2f(x + 70, y + 20);
        glVertex2f(x + 52, y + 5);//bottom leg
        glVertex2f(x + 70, y - 8);
    glEnd();
    glLineWidth(1.0f);

    glBegin(GL_LINES);
        glVertex2f(x - 4, y + 12);
        glVertex2f(x + 2, y + 6);
        glVertex2f(x + 2, y + 12);
        glVertex2f(x - 4, y + 6);
    glEnd();
}

// ---------------- HOSPITAL INSIDE SCENE ----------------
void drawSmallPerson(float x, float y, float r, float g, float b) {
    drawCircle(x, y + 38, 11, 0.95f, 0.75f, 0.55f);
    drawRectangle(x - 10, y + 8, 20, 28, r, g, b);

    glColor3f(0.0f, 0.0f, 0.0f);
    glLineWidth(3.0f);
    glBegin(GL_LINES);
        glVertex2f(x - 5, y + 8);
        glVertex2f(x - 12, y - 15);

        glVertex2f(x + 5, y + 8);
        glVertex2f(x + 12, y - 15);

        glVertex2f(x - 10, y + 30);
        glVertex2f(x - 25, y + 15);

        glVertex2f(x + 10, y + 30);
        glVertex2f(x + 25, y + 15);
    glEnd();
    glLineWidth(1.0f);
}

void drawNurse(float x, float y, float runOffset) {
    drawCircle(x, y + 42, 11, 0.95f, 0.75f, 0.55f);
    drawRectangle(x - 12, y + 12, 24, 30, 1.0f, 1.0f, 1.0f);

    // nurse cap
    drawRectangle(x - 14, y + 52, 28, 8, 1.0f, 1.0f, 1.0f);
    drawRectangle(x - 3, y + 53, 6, 6, 1.0f, 0.0f, 0.0f);

    glColor3f(0.0f, 0.0f, 0.0f);
    glLineWidth(3.0f);
    glBegin(GL_LINES);
        // running legs
        glVertex2f(x - 5, y + 12);
        glVertex2f(x - 20 - runOffset, y - 10);

        glVertex2f(x + 5, y + 12);
        glVertex2f(x + 22 + runOffset, y - 10);

        // running hands
        glVertex2f(x - 12, y + 35);
        glVertex2f(x - 32 - runOffset, y + 22);

        glVertex2f(x + 12, y + 35);
        glVertex2f(x + 32 + runOffset, y + 22);
    glEnd();
    glLineWidth(1.0f);
}

void drawDoctor(float x, float y) {
    drawCircle(x, y + 45, 12, 0.95f, 0.75f, 0.55f);
    drawRectangle(x - 14, y + 10, 28, 35, 1.0f, 1.0f, 1.0f);

    // stethoscope
    glColor3f(0.0f, 0.0f, 0.0f);
    glLineWidth(2.0f);
    glBegin(GL_LINES);
        glVertex2f(x - 7, y + 38);
        glVertex2f(x - 2, y + 25);

        glVertex2f(x + 7, y + 38);
        glVertex2f(x + 2, y + 25);
    glEnd();
    drawCircle(x, y + 23, 4, 0.0f, 0.0f, 0.0f);

    // legs and hands
    glColor3f(0.0f, 0.0f, 0.0f);
    glLineWidth(3.0f);
    glBegin(GL_LINES);
        glVertex2f(x - 5, y + 10);
        glVertex2f(x - 12, y - 15);

        glVertex2f(x + 5, y + 10);
        glVertex2f(x + 12, y - 15);

        glVertex2f(x - 14, y + 35);
        glVertex2f(x - 30, y + 22);

        glVertex2f(x + 14, y + 35);
        glVertex2f(x + 30, y + 22);
    glEnd();
    glLineWidth(1.0f);
}

void drawPatientOnBed(float x, float y) {
    // bed
    drawRectangle(x, y, 150, 18, 0.60f, 0.60f, 0.65f);
    drawRectangle(x + 10, y + 18, 130, 18, 0.80f, 0.92f, 1.0f);

    // pillow
    drawRectangle(x + 8, y + 35, 35, 15, 1.0f, 1.0f, 1.0f);

    // patient lying
    drawCircle(x + 35, y + 55, 10, 0.95f, 0.75f, 0.55f);
    drawRectangle(x + 45, y + 42, 70, 12, 0.20f, 0.40f, 0.90f);

    // bed wheels
    drawCircle(x + 25, y - 5, 7, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 125, y - 5, 7, 0.05f, 0.05f, 0.05f);
}

void drawDetailedPatientBed(float x, float y, float scale) {
    glPushMatrix();
        glTranslatef(x, y, 0);
        glScalef(scale, scale, 1.0f);

        // Bed shadow
        drawRectangle(-78, -112, 156, 224, 0.45f, 0.50f, 0.52f);

        // Bed frame
        drawRectangle(-85, -120, 170, 240, 0.25f, 0.25f, 0.25f);

        // Mattress
        drawRectangle(-72, -108, 144, 216, 1.0f, 1.0f, 1.0f);

        // Side rails
        drawRectangle(-88, -88, 12, 176, 0.35f, 0.35f, 0.35f);
        drawRectangle(76, -88, 12, 176, 0.35f, 0.35f, 0.35f);

        // Head board
        drawRectangle(-88, 108, 176, 20, 0.40f, 0.40f, 0.40f);

        // Foot board
        drawRectangle(-88, -128, 176, 20, 0.40f, 0.40f, 0.40f);

        // Pillow
        drawRectangle(-48, 72, 96, 32, 0.88f, 0.90f, 1.0f);

        // Patient head
        drawCircle(0, 65, 19, 0.95f, 0.72f, 0.55f);

        // Hair
        //drawCircle(0, 78, 13, 0.06f, 0.03f, 0.02f);

        // Neck
        drawRectangle(-7, 40, 14, 18, 0.95f, 0.72f, 0.55f);

        // Body
        drawRectangle(-28, -32, 56, 72, 0.15f, 0.45f, 0.85f);

        // Arms
        glColor3f(0.95f, 0.72f, 0.55f);
        glLineWidth(6.0f);
        glBegin(GL_LINES);
            glVertex2f(-28, 24);
            glVertex2f(-56, -16);

            glVertex2f(28, 24);
            glVertex2f(56, -16);
        glEnd();
        glLineWidth(1.0f);

        // Hands
        drawCircle(-58, -18, 7, 0.95f, 0.72f, 0.55f);
        drawCircle(58, -18, 7, 0.95f, 0.72f, 0.55f);

        // Blanket
        drawRectangle(-52, -100, 104, 92, 0.50f, 0.78f, 0.95f);

        // Blanket top border
        glColor3f(0.10f, 0.45f, 0.65f);
        glLineWidth(3.0f);
        glBegin(GL_LINES);
            glVertex2f(-52, -8);
            glVertex2f(52, -8);

            glVertex2f(-24, -15);
            glVertex2f(-24, -92);

            glVertex2f(24, -15);
            glVertex2f(24, -92);
        glEnd();
        glLineWidth(1.0f);

        // Face details
        drawCircle(-7, 65, 2, 0.0f, 0.0f, 0.0f);
        drawCircle(7, 65, 2, 0.0f, 0.0f, 0.0f);

        glColor3f(0.0f, 0.0f, 0.0f);
        glLineWidth(1.5f);
        glBegin(GL_LINES);
            glVertex2f(-7, 56);
            glVertex2f(7, 56);
        glEnd();
        glLineWidth(1.0f);

        // IV stand
        drawCircle(120, 25, 12, 0.25f, 0.25f, 0.25f);

        glColor3f(0.25f, 0.25f, 0.25f);
        glLineWidth(3.0f);
        glBegin(GL_LINES);
            glVertex2f(120, 25);
            glVertex2f(120, -58);
        glEnd();
        glLineWidth(1.0f);

        // IV bag
        drawRectangle(104, 35, 32, 42, 0.90f, 0.95f, 1.0f);

        // Tube
        glColor3f(0.05f, 0.05f, 0.05f);
        glLineWidth(1.5f);
        glBegin(GL_LINES);
            glVertex2f(120, 35);
            glVertex2f(58, -18);
        glEnd();
        glLineWidth(1.0f);

        // Small medical cross board
        drawRectangle(-145, 110, 40, 40, 1.0f, 1.0f, 1.0f);
        drawRectangle(-129, 115, 8, 30, 1.0f, 0.0f, 0.0f);
        drawRectangle(-140, 126, 30, 8, 1.0f, 0.0f, 0.0f);

    glPopMatrix();
}

void drawStretcherWithPatient(float x, float y) {
    // stretcher
    drawRectangle(x, y, 190, 16, 0.55f, 0.55f, 0.60f);
    drawRectangle(x + 8, y + 16, 174, 14, 0.75f, 0.90f, 1.0f);

    // patient
    drawCircle(x + 45, y + 48, 11, 0.95f, 0.75f, 0.55f);
    drawRectangle(x + 56, y + 35, 85, 12, 0.10f, 0.20f, 0.80f);

    // wheels
    drawCircle(x + 35, y - 6, 8, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 150, y - 6, 8, 0.05f, 0.05f, 0.05f);

    // medical red cross on blanket
    drawRectangle(x + 95, y + 39, 20, 5, 1.0f, 0.0f, 0.0f);
    drawRectangle(x + 102, y + 32, 5, 20, 1.0f, 0.0f, 0.0f);
}

void drawWaitingBench(float x, float y) {
    drawRectangle(x, y, 180, 18, 0.45f, 0.25f, 0.10f);
    drawRectangle(x, y + 45, 180, 16, 0.45f, 0.25f, 0.10f);

    glColor3f(0.15f, 0.15f, 0.15f);
    glLineWidth(4.0f);
    glBegin(GL_LINES);
        glVertex2f(x + 20, y);
        glVertex2f(x + 20, y - 30);

        glVertex2f(x + 160, y);
        glVertex2f(x + 160, y - 30);

        glVertex2f(x + 10, y + 45);
        glVertex2f(x + 10, y);
    glEnd();
    glLineWidth(1.0f);
}

void drawHospitalInsideScene() {
    // inside background
    drawRectangle(0, 0, 1600, 900, 0.88f, 0.96f, 1.0f);

    // floor
    drawRectangle(0, 0, 1600, 250, 0.75f, 0.82f, 0.85f);

    // wall line
    drawRectangle(0, 250, 1600, 5, 0.55f, 0.65f, 0.70f);

    // title board
    drawRectangle(560, 805, 480, 55, 0.0f, 0.45f, 0.70f);
    drawTextBlack(665, 825, "HOSPITAL EMERGENCY WARD");

    // ICU door
    drawRectangle(920, 330, 280, 390, 0.85f, 0.95f, 1.0f);
    drawRectangle(935, 345, 250, 360, 0.70f, 0.90f, 1.0f);
    drawRectangle(1040, 345, 8, 360, 0.20f, 0.45f, 0.60f);

    drawRectangle(995, 720, 135, 45, 1.0f, 0.0f, 0.0f);
    drawTextBlack(1035, 735, "ICU");

    drawCircle(1025, 525, 8, 0.10f, 0.10f, 0.10f);
    drawCircle(1065, 525, 8, 0.10f, 0.10f, 0.10f);

    // doctor room on the right side
    drawRectangle(1450, 330, 125, 390, 0.92f, 0.92f, 0.96f);
    drawRectangle(1465, 345, 95, 360, 0.78f, 0.88f, 0.95f);
    drawRectangle(1478, 720, 75, 45, 0.0f, 0.45f, 0.70f);
    drawTextBlack(1480, 735, "ROOM");
    drawTextBlack(1462, 300, "Doctor Room");
    drawCircle(1478, 525, 7, 0.10f, 0.10f, 0.10f);

    // emergency red light blinking
    float blink = fabs(sin(environmentFrame * 0.18f));
    drawCircle(1165, 745, 18 + blink * 5, 1.0f, 0.0f, 0.0f);

    // treatment beds
    // 5 detailed bed with patient
    // 5 detailed bed with patient in one single row
    drawDetailedPatientBed(120, 610, 0.48f);
    drawDetailedPatientBed(300, 610, 0.48f);
    drawDetailedPatientBed(480, 610, 0.48f);
    drawDetailedPatientBed(660, 610, 0.48f);
    drawDetailedPatientBed(840, 610, 0.48f);

drawTextBlack(120, 745, "Patients taking treatment");
    // waiting patients
    drawWaitingBench(120, 160);
    drawSmallPerson(165, 165, 0.25f, 0.45f, 1.0f);
    drawSmallPerson(225, 165, 0.20f, 0.70f, 0.30f);
    drawSmallPerson(285, 165, 0.90f, 0.60f, 0.20f);
    drawTextBlack(120, 100, "Patients waiting after treatment");

    // emergency equipment table
    drawRectangle(720, 155, 220, 80, 0.95f, 0.95f, 0.95f);
    drawRectangle(740, 235, 180, 20, 0.70f, 0.70f, 0.75f);
    drawRectangle(800, 260, 50, 18, 1.0f, 0.0f, 0.0f);
    drawRectangle(818, 244, 14, 50, 1.0f, 0.0f, 0.0f);
    drawTextBlack(755, 115, "Emergency equipment");

    // trolley moving from left to ICU
    if (!patientInsideICU) {
        drawStretcherWithPatient(hospitalTrolleyX, 325);

        float runOffset = sin(environmentFrame * 0.25f) * 8.0f;

        // nurses moving with trolley
        drawNurse(hospitalTrolleyX - 70, 330, runOffset);
        drawNurse(hospitalTrolleyX + 220, 330, -runOffset);
    }

    // patient inside ICU after keyboard press
    if (patientInsideICU) {
        drawTextBlack(960, 300, "Patient taken inside ICU");
    }

    // doctor running from left to right after 2 seconds
    if (doctorStartRunning || doctorReachedICU) {
        float doctorRunOffset = sin(environmentFrame * 0.35f) * 8.0f;

        drawDoctor(hospitalDoctorX, 335);

        if (!doctorReachedICU) {
            // running effect lines near doctor
            glColor3f(0.0f, 0.0f, 0.0f);
            glLineWidth(2.0f);
            glBegin(GL_LINES);
                glVertex2f(hospitalDoctorX + 55, 370);
                glVertex2f(hospitalDoctorX + 25 + doctorRunOffset, 370);

                glVertex2f(hospitalDoctorX + 65, 350);
                glVertex2f(hospitalDoctorX + 35 + doctorRunOffset, 350);

                glVertex2f(hospitalDoctorX + 55, 330);
                glVertex2f(hospitalDoctorX + 25 + doctorRunOffset, 330);
            glEnd();
            glLineWidth(1.0f);
        }
    }

    if (doctorReachedICU) {
        drawTextBlack(1120, 285, "Doctor reached ICU");
    }

    // instruction text
    if (!trolleyReachedICU) {
        drawTextBlack(40, 850, "Trolley is moving toward ICU...");
    }
    else if (trolleyReachedICU && !patientInsideICU) {
        drawTextBlack(40, 850, "Trolley stopped near ICU. Press ENTER to take patient inside ICU.");
    }
    else if (patientInsideICU && !doctorStartRunning && !doctorReachedICU) {
        drawTextBlack(40, 850, "Patient entered ICU. Doctor will come after 2 seconds.");
        drawTextBlack(40, 820, "After doctor starts moving, hold LEFT MOUSE to increase doctor speed.");
    }
    else if (doctorStartRunning && !doctorReachedICU) {
        drawTextBlack(40, 850, "Doctor is running toward ICU... Hold LEFT MOUSE to increase speed.");
        drawTextBlack(40, 820, "Release mouse to slow down. Doctor will still move slowly.");
    }
    else {
        drawTextBlack(40, 850, "Emergency treatment started inside ICU.");
        drawTextBlack(40, 820, "Mouse speed control completed.");
    }
}

// ---------------- AMBULANCE ----------------
void drawAmbulance(float x, float y) {
    drawRectangle(x, y, 150, 45, 1.0f, 1.0f, 1.0f);
    drawRectangle(x + 105, y + 18, 45, 35, 1.0f, 1.0f, 1.0f);

    drawRectangle(x + 112, y + 28, 28, 18, 0.60f, 0.85f, 1.0f);
    drawRectangle(x + 20, y + 25, 30, 15, 0.60f, 0.85f, 1.0f);
    drawRectangle(x + 58, y + 25, 30, 15, 0.60f, 0.85f, 1.0f);

    drawRectangle(x, y + 8, 150, 8, 1.0f, 0.0f, 0.0f);
    drawRectangle(x + 62, y + 20, 20, 7, 1.0f, 0.0f, 0.0f);
    drawRectangle(x + 68, y + 14, 7, 20, 1.0f, 0.0f, 0.0f);

    drawRectangle(x + 65, y + 48, 25, 8, 1.0f, 0.0f, 0.0f);
    drawCircle(x + 77, y + 58, 5, 0.0f, 0.0f, 1.0f);

    drawCircle(x + 150, y + 20, 5, 1.0f, 1.0f, 0.50f);

    drawCircle(x + 35, y - 3, 14, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 115, y - 3, 14, 0.05f, 0.05f, 0.05f);
    drawCircle(x + 35, y - 3, 7, 0.55f, 0.55f, 0.55f);
    drawCircle(x + 115, y - 3, 7, 0.55f, 0.55f, 0.55f);

    drawText(x + 25, y + 58, "AMBULANCE");
}

void drawVerticalAmbulance(float x, float y) {
    glPushMatrix();
        glTranslatef(x + 75, y + 22, 0);
        glRotatef(-90.0f, 0, 0, 1);
        drawAmbulance(-75, -22);
    glPopMatrix();
}

void drawCollisionEffect() {
    float crashX = (crashedRedCarX + 130 + crashedBlueCarX) / 2.0f;

    drawCircle(crashX, 325, 35, 1.0f, 0.45f, 0.0f);
    drawCircle(crashX + 20, 338, 22, 1.0f, 0.85f, 0.0f);
    drawCircle(crashX - 18, 340, 18, 1.0f, 0.0f, 0.0f);
    drawCircle(crashX + 5, 355, 15, 0.25f, 0.25f, 0.25f);

    glColor3f(1.0f, 1.0f, 0.0f);
    glLineWidth(3.0f);
    glBegin(GL_LINES);
        glVertex2f(crashX, 325); glVertex2f(crashX - 45, 370);
        glVertex2f(crashX, 325); glVertex2f(crashX + 45, 370);
        glVertex2f(crashX, 325); glVertex2f(crashX - 50, 300);
        glVertex2f(crashX, 325); glVertex2f(crashX + 50, 300);
        glVertex2f(crashX, 325); glVertex2f(crashX, 385);
    glEnd();
    glLineWidth(1.0f);

    drawText(crashX - 55, 390, "COLLISION!");
}

// ---------------- BACKGROUND ----------------
void drawBackground() {
    if (environmentMode == 'n') {
        drawRectangle(0, 0, 1600, 900, 0.02f, 0.03f, 0.12f);//dark night sky
        drawCircle(1350, 780, 45, 0.95f, 0.95f, 0.75f);//yellow moon draw
        drawCircle(1370, 795, 42, 0.02f, 0.03f, 0.12f);//sky color moon affect
        drawTwinklingStars();
        drawRectangle(0, 0, 1600, 240, 0.04f, 0.22f, 0.08f);//lower green ground
    }
    else if (environmentMode == 'w') {
        drawRectangle(0, 0, 1600, 900, 0.78f, 0.88f, 0.95f);//screen light bluish sky
        drawCircle(1400, 780, 45, 0.95f, 0.95f, 0.80f);//winter sun
        drawRectangle(0, 0, 1600, 240, 0.92f, 0.96f, 1.0f);
    }
    else if (environmentMode == 'd') {
        drawRectangle(0, 0, 1600, 900, 0.42f, 0.48f, 0.55f);//screen grayish sky
        drawCircle(1400, 780, 45, 0.70f, 0.70f, 0.62f);//sun of color dull gray-yellow
        drawRectangle(0, 0, 1600, 240, 0.07f, 0.38f, 0.12f);//Wet green ground
    }
    else {
        drawRectangle(0, 0, 1600, 900, 0.55f, 0.80f, 1.0f);//Full screen sky-blue color
        drawCircle(1400, 780, 55, 1.0f, 0.85f, 0.10f);//Bright sun
        drawRectangle(0, 0, 1600, 240, 0.12f, 0.55f, 0.18f);//Green ground

    }

    //Main road draw section

    if (environmentMode == 'w') {
        drawRectangle(0, 240, 1600, 140, 0.70f, 0.75f, 0.78f);//outer/base part
        drawRectangle(0, 255, 1600, 110, 0.82f, 0.86f, 0.88f);//road-eer vitore  lighter part
    }
    else if (environmentMode == 'r') {
        drawRectangle(0, 240, 1600, 140, 0.08f, 0.08f, 0.10f);//dark road base
        drawRectangle(0, 260, 1600, 90, 0.13f, 0.13f, 0.16f);//lighter wet road surface:
    }
    else {
        drawRectangle(0, 240, 1600, 140, 0.18f, 0.18f, 0.20f);
    }


    //Road border line
    drawRectangle(0, 238, 1600, 4, 1.0f, 1.0f, 1.0f);//Bottom border
    drawRectangle(0, 378, 1600, 4, 1.0f, 1.0f, 1.0f);//Top border

    glColor3f(1.0f, 1.0f, 1.0f);
    glLineWidth(4.0f);
    // main road dash line
    for (int x = 0; x < 1600; x += 90) {
        glBegin(GL_LINES);
            glVertex2f(x + 10, 310);
            glVertex2f(x + 60, 310);
        glEnd();
    }
    glLineWidth(1.0f);
}

// ---------------- DISPLAY FUNCTION ----------------
void display() {
    glClear(GL_COLOR_BUFFER_BIT);

    if (showHospitalInside) {
        drawHospitalInsideScene();
        glFlush();
        return;
    }

    drawBackground();
    drawDecorativeGrassLand();
    drawCurvedConnectingRoads();

    drawBottomAsymmetricTrees();
    drawTopStraightRoadTrees();

    drawTree(430, 430, 0.75f);
    drawTree(1050, 430, 0.75f);
    drawTree(1180, 430, 0.60f);
    drawTree(520, 420, 0.55f);
    drawTree(960, 420, 0.55f);

    glPushMatrix();
        glTranslatef(20, BUILDING_Y, 0);
        glScalef(0.65f, 0.65f, 1.0f);
        drawSchool();
    glPopMatrix();

    glPushMatrix();
        glTranslatef(660, BUILDING_Y, 0);
        glScalef(0.65f, 0.65f, 1.0f);
        drawHospital();
    glPopMatrix();

    glPushMatrix();
        glTranslatef(1300, BUILDING_Y, 0);
        glScalef(0.65f, 0.65f, 1.0f);
        drawPoliceStation();
    glPopMatrix();

    if (showStudents) {
        drawStudent(student1X, student1Y, 1.0f, 1.0f, 0.0f);
        drawStudent(student2X, student2Y, 0.0f, 1.0f, 0.0f);
    }

    if (!crashed) {
        drawCar(carX, 285);

        if (sceneState >= 4) {
            drawCarReverse(car2X, 285);
        }
    }
    else {
        // Red car grass side e pore thakbe, blue car road er upor thakbe
        drawCrashedRedCar(crashedRedCarX, crashedRedCarY, redCarAngle);
        drawCrashedBlueCar(crashedBlueCarX, crashedBlueCarY, blueCarAngle);
        drawCollisionEffect();

        if (showDeadBody) {
            // Dead body collision spot-e fixed thakbe
            drawDeadBody(deadBodyX, deadBodyY);
        }
    }

    if (showAmbulance) {
        if (ambulanceOnHospitalRoad) {
            drawVerticalAmbulance(ambulanceX, ambulanceY);
        }
        else {
            drawAmbulance(ambulanceX, ambulanceY);
        }
    }

    drawWeatherOverlay();
    drawInstructionPanel();

    glFlush();
}

// ---------------- KEYBOARD FUNCTION ----------------
void keyboard(unsigned char key, int x, int y) {
    if (key == 's' || key == 'S') {
        if (sceneState == 3) {
            startByKeyboard = true;
        }
    }

    if (key == 'd' || key == 'D') {
        environmentMode = 'd';
    }

    if (key == 'w' || key == 'W') {
        environmentMode = 'w';
    }

    if (key == 'r' || key == 'R') {
        environmentMode = 'r';
    }

    if (key == 'n' || key == 'N') {
        environmentMode = 'n';
    }
    if (showHospitalInside && trolleyReachedICU && !patientInsideICU) {
       if (key == 13 || key == ' ') {
        patientInsideICU = true;
        allowPatientEnterICU = true;
        patientEnterCounter = 0;
      }
    }

    glutPostRedisplay();
}


// ---------------- MOUSE FUNCTION ----------------
void mouse(int button, int state, int x, int y) {
    if (button == GLUT_LEFT_BUTTON) {

        if (state == GLUT_DOWN) {
            // ambulance accident spot e pouchanor por click korle hospital inside scene open hobe
            if (sceneState == 5 && ambulanceReached && !showHospitalInside) {
                showHospitalInside = true;

                // hospital scene reset
                hospitalTrolleyX = -250.0f;
                trolleyReachedICU = false;
                patientInsideICU = false;
                allowPatientEnterICU = false;
                patientEnterCounter = 0;

                hospitalDoctorX = 1540.0f;
                doctorStartRunning = false;
                doctorReachedICU = false;
                doctorSpeed = 0.0f;
                doctorMousePressed = false;
            }
            else {
                // hospital scene er moddhe doctor speed control
                doctorMousePressed = true;
            }
        }

        if (state == GLUT_UP) {
            doctorMousePressed = false;
        }
    }

    glutPostRedisplay();
}

// ---------------- TIMER FUNCTION ----------------
void timer(int value) {
    environmentFrame++;

    // Hospital inside scene animation
    if (showHospitalInside) {
        // trolley left theke right e ICU porjonto move korbe
        if (!trolleyReachedICU) {
            hospitalTrolleyX += 7.0f;//trolly speed

            // ICU door er shamne trolley thambe
            if (hospitalTrolleyX >= 700.0f) {
                hospitalTrolleyX = 700.0f;
                trolleyReachedICU = true;
            }
        }

        // patient ICU te jawar 2 second por doctor run start korbe
        if (patientInsideICU && !doctorStartRunning && !doctorReachedICU) {
            patientEnterCounter++;

            // timer 30ms, so 2 sec approx = 2000 / 30 = 66 frames
            if (patientEnterCounter >= 66) {
                doctorStartRunning = true;
                hospitalDoctorX = 1540.0f;
                doctorSpeed = doctorMinSpeed;   // doctor initially aste start korbe
                doctorMousePressed = false;
            }
        }

        // doctor right side er room theke left dike ICU er kache eshe thambe
        // mouse click hold korle speed barbe, click chere dile speed aste aste kombe
        if (doctorStartRunning && !doctorReachedICU) {

            if (doctorMousePressed) {
                doctorSpeed += doctorAcceleration;

                if (doctorSpeed > doctorMaxSpeed) {
                    doctorSpeed = doctorMaxSpeed;
                }
            }
            else {//button not pressed
                doctorSpeed -= doctorFriction;

                if (doctorSpeed < doctorMinSpeed) {
                    doctorSpeed = doctorMinSpeed;
                }
            }

            hospitalDoctorX -= doctorSpeed;

            if (hospitalDoctorX <= 1230.0f) {
                hospitalDoctorX = 1230.0f;
                doctorReachedICU = true;
                doctorStartRunning = false;
                doctorSpeed = 0.0f;
                doctorMousePressed = false;
            }
        }

        glutPostRedisplay();
        glutTimerFunc(30, timer, 0);
        return;
    }

    // 0 = red car coming from left to school
    if (sceneState == 0) {
        carX += 3.33f;

        if (carX >= schoolStopX) {
            carX = schoolStopX;
            sceneState = 1;
            waitCounter = 0;
        }
    }

    // 1 = red car stopped in front of school
    else if (sceneState == 1) {
        waitCounter++;

        if (waitCounter > 35) {
            sceneState = 2;
        }
    }
    // 2 = students going to car
    else if (sceneState == 2) {
        float target1X = carX + 65.0f;
        float target2X = carX + 85.0f;
        float targetY = 345.0f;

        if (student1Y > targetY)
            student1Y -= 4.0f;
        if (student2Y > targetY)
            student2Y -= 4.0f;

        if (student1X < target1X)
            student1X += 2.0f;
        if (student2X < target2X)
            student2X += 2.0f;

        if (student1Y <= targetY && student2Y <= targetY &&
            student1X >= target1X && student2X >= target2X) {
            showStudents = false;
            sceneState = 3;
            waitCounter = 0;
        }
    }
    // 3 = students entered car, waiting for S key
    else if (sceneState == 3) {
        if (startByKeyboard) {
            sceneState = 4;
            car2X = 1700.0f;
            startByKeyboard = false;
        }
    }
    // 4 = red car starts again, blue car comes from right
    else if (sceneState == 4) {
        carX += 4.0f;
        car2X -= 6.0f;


        if (carX + 130 >= car2X && carX <= car2X + 130) {
            crashed = true;
            sceneState = 5;
            crashSoundCounter = 0;
            accidentAfterCounter = 0;

            crashedRedCarX = carX;
            crashedBlueCarX = car2X;
            crashedRedCarY = 285.0f;
            crashedBlueCarY = 285.0f;

            redCarAngle = 0.0f;
            blueCarAngle = 0.0f;

            showDeadBody = true;

            float crashX = (carX + 130 + car2X) / 2.0f;
            ambulanceTargetX = crashX - 170.0f;

            // Dead body collision spot-e fixed rakhar jonno position save
            deadBodyX = crashX + 20.0f;
            deadBodyY = 260.0f;

            // Ambulance red car er original start side theke ashbe
            ambulanceX = -220.0f;      // screen er left side er baire
            ambulanceY = 285.0f;       // main road e
            ambulanceOnHospitalRoad = false;

            showAmbulance = false;
            ambulanceReached = false;

            if (!accidentSoundPlayed) {
                playAccidentSound();
                accidentSoundPlayed = true;
            }
        }
    }
    // 5 = collision and ambulance scene
    else if (sceneState == 5) {
        crashSoundCounter++;
        accidentAfterCounter++;

        if (accidentAfterCounter < 45) {
            // Red car road er pasher grass er dike pore jabe
            crashedRedCarX -= 4.5f;

            if (crashedRedCarY > 235.0f) {
                crashedRedCarY -= 2.0f;
            }

            // Blue car road er upor right side e sore jabe
            crashedBlueCarX += 6.0f;

            redCarAngle += 4.0f;
            blueCarAngle -= 3.0f;
        }

        if (crashSoundCounter > 140 && !ambulanceSoundPlayed) {
            showAmbulance = true;
            playAmbulanceSound();
            ambulanceSoundPlayed = true;
        }

        if (showAmbulance && !ambulanceReached) {
            // ambulance red car er starting side theke accident spot er dike ashbe
            if (ambulanceX < ambulanceTargetX) {
                ambulanceX += 5.0f;
            }

            if (ambulanceX >= ambulanceTargetX) {
                ambulanceX = ambulanceTargetX;
                ambulanceReached = true;
            }
        }

        if (crashSoundCounter > 350 && !sadSoundPlayed) {
            playSadSound();
            sadSoundPlayed = true;
        }
    }

    glutPostRedisplay();
    glutTimerFunc(30, timer, 0);
}

// ---------------- INIT FUNCTION ----------------
void init() {
    glClearColor(0.02f, 0.03f, 0.12f, 1.0f);

    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(0, 1600, 0, 900);

    glMatrixMode(GL_MODELVIEW);
}

// ---------------- MAIN FUNCTION ----------------
int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(1600, 900);
    glutInitWindowPosition(50, 50);
    glutCreateWindow("School Car Accident");

    init();

    glutDisplayFunc(display);
    glutKeyboardFunc(keyboard);
    glutMouseFunc(mouse);
    glutTimerFunc(30, timer, 0);

    glutMainLoop();
    return 0;
}
