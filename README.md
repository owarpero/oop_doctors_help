# Lab 1

## ������� �5

### ���⠢ �������:

- �ન� ����ᠭ�� ��ࣥ����
- �㭮� ��⢥� ��⠫쥢��
- ���� ����� ��������
- ��୨���� ��堨� ��쥢��
- ���� ����ᥩ ��ࣥ����

### ����:

�����஭��� ��⥬� ����� � ��砬

### ��魮��:

#### Users:
- user_id: int (AI)
- name: string 
- surname: string 
- phone: string (unique)
- email: string (unique)
- hashed_password: string
- birthdate: datetime
- role: enum (USER, DOCTOR, ADMINISTRATOR)

#### Specializations:
- specialization_id: int (AI)
- name: string
- description: string

#### Employees:
- employee_id: int (AI)
- user: int -> Users
- specialization: int -> Specializations
- graduate: string
- experience: string

#### Schedule:
- schedule_id: int (AI)
- doctor_id: int -> Employees
- date_start: datetime with timestamp
- date_end: datetime with timestamp
- status: enum (AVAILABLE/UNAVAILABLE)

#### Appointments:
- appointment_id: int (AI)
- patient_id: int -> Users
- schedule_id: int -> Schedule
- created_at: datetime with timestamp [auto]
- updated_at: datetime with timestamp [auto]
- status: enum (PLANNED, CANCELLED, FINISHED)

#### Reviews:
- review_id: int (IA)
- appointment_id: int -> Appointments
- grade: int (1, 2, 3, 4, 5)
- comment: string
- created_at: datetime with timestamp [auto]
- updated_at: datetime with timestamp [auto]


#### �������:
Users(phone; email)
Employees(user; specialization)
Schedule(doctor_id, date_start, date_end, status)
Appointments(patient_id, status)