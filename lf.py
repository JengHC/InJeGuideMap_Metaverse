import os
import sys

def main(gitssh, branch):
    path_dir = './'
    lf_list = []
    total_lfs_size = 0

    print("LF target:")
    for (root, directories, files) in os.walk(path_dir):
        for file in files:
            file_path = os.path.join(root, file)

            file_size = os.path.getsize(file_path)
            if file_size > 5242800:
                lf_list.append(file)
                total_lfs_size += file_size

                print('\t' + file + '\t' + str(file_size) + ' Byte')

    print(f'\n\n\tTotal LFS Size: {total_lfs_size} Byte')
    f = open("./lf.bat", 'w')

    f.write('git init\n')
    f.write('git lfs install\n\n')

    for file_name in lf_list:
        f.write('git lfs track ' + file_name + '\n')

    f.write('\ngit add *\n')
    f.write('git commit -m \"commit by lfs\"')

    f.write('\ngit checkout -b ' + branch + '\n')
    f.write('git remote add origin ' + gitssh + '\n')
    f.write('git push origin ' + branch + '\n')

    f.close()

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('매개변수가 틀립니다.')
    else:  
        main(sys.argv[1], sys.argv[2])