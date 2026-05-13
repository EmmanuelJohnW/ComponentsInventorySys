-- ============================================================
-- Electronics Inventory System — SQLite Schema
-- ============================================================
-- This schema is applied automatically by DataStore.EnsureSchema()
-- on the first run. The database file is created at:
--   <app directory>/inventory.db
--
-- You can also apply this manually with any SQLite client:
--   sqlite3 inventory.db < sqlite_schema.sql
-- ============================================================

PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS components (
    component_id INTEGER PRIMARY KEY AUTOINCREMENT,
    part_no      TEXT    NOT NULL UNIQUE,
    manufacturer TEXT    NOT NULL,
    part_name    TEXT    NOT NULL,
    qty          INTEGER NOT NULL DEFAULT 0 CHECK (qty >= 0),
    unit_cost    REAL    NOT NULL DEFAULT 0 CHECK (unit_cost >= 0),
    status       TEXT    NOT NULL DEFAULT 'In Stock'
                 CHECK (status IN ('In Stock', 'Checked Out', 'Defective'))
);

CREATE TABLE IF NOT EXISTS projects (
    project_id   INTEGER PRIMARY KEY AUTOINCREMENT,
    project_name TEXT NOT NULL,
    project_code TEXT NOT NULL UNIQUE,
    lead_name    TEXT,
    email        TEXT
);

CREATE TABLE IF NOT EXISTS checkouts (
    checkout_id   INTEGER PRIMARY KEY AUTOINCREMENT,
    component_id  INTEGER NOT NULL REFERENCES components(component_id),
    project_id    INTEGER NOT NULL REFERENCES projects(project_id),
    checkout_date TEXT    NOT NULL,
    return_date   TEXT    NOT NULL,
    total_value   REAL    NOT NULL,
    status        TEXT    NOT NULL DEFAULT 'Checked Out',
    CHECK (return_date > checkout_date)
);
